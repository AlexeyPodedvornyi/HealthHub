using HealthHub.MVVM.Commands;
using HealthHub.MVVM.Models.Doctors;
using HealthHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HealthHub.MVVM.ViewModels
{
    public class DoctorsScheduleAddViewModel : ViewModel
    {
        private readonly IDialogService _dialogService;
        private readonly IDoctorScheduleService _doctorScheduleService;

        private Doctor _doctor;
        private DoctorsSchedule? _comboboxSelectedItem;
        private List<DoctorsSchedule> _doctorsSchedules;
        private DateTimeOffset _startTime;
        private DateTimeOffset _endTime;
        private bool _isSameTimeForAllChecked;
        private int? _selectedStartHour;
        private int? _selectedStartMinute;
        private int? _selectedEndHour;
        private int? _selectedEndMinute;

        public Doctor Doctor
        {
            get => _doctor;
        }
        public DoctorsSchedule? ComboboxSelectedItem
        {
            get => _comboboxSelectedItem;
            set
            {
                _comboboxSelectedItem = value;
                OnPropertyChanged(nameof(ComboboxSelectedItem));
            }
        }
        public List<DoctorsSchedule> DoctorsSchedules
        {
            get => _doctorsSchedules;
            set
            {
                _doctorsSchedules = value;
                OnPropertyChanged(nameof(DoctorsSchedules));
            }
        }
        public int? SelectedStartHour
        {
            get => _selectedStartHour;
            set
            {
                _selectedStartHour = value;
                OnPropertyChanged(nameof(SelectedStartHour));
            }
        }
        public int? SelectedStartMinute
        {
            get => _selectedStartMinute;
            set
            {
                _selectedStartMinute = value;
                OnPropertyChanged(nameof(SelectedStartMinute));
            }
        }
        public int? SelectedEndHour
        {
            get => _selectedEndHour;
            set
            {
                _selectedEndHour = value;
                OnPropertyChanged(nameof(SelectedEndHour));
            }
        }
        public int? SelectedEndMinute
        {
            get => _selectedEndMinute;
            set
            {
                _selectedEndMinute = value;
                OnPropertyChanged(nameof(SelectedEndMinute));
            }
        }
        public bool IsSameTimeForAllChecked
        {
            get => _isSameTimeForAllChecked;
            set
            {
                _isSameTimeForAllChecked = value;
                OnPropertyChanged(nameof(IsSameTimeForAllChecked));
            }
        }
        public List<int> WorkingHoursPool { get; private set; }
        public List<int> MinutesPool { get; private set; }


        public ICommand ApplyChangesCommand { get; }
        public ICommand AddScheduleCommand { get; }
        public ICommand ResetInputsCommand { get; }
        public DoctorsScheduleAddViewModel(IDialogService dialogService, IDoctorScheduleService doctorScheduleService)
        {
            _dialogService = dialogService;
            _doctorScheduleService = doctorScheduleService;

            ApplyChangesCommand = new RelayCommand(exec => ApplyWorkingSchedule());
            ResetInputsCommand = new RelayCommand(exec => ResetInputs());
            AddScheduleCommand = new RelayCommand(async exec => await AddSchedule());

            WorkingHoursPool = Enumerable.Range(7, 14).ToList();
            MinutesPool = Enumerable.Range(0, 60)
                .Where(x => x % 5 == 0 || x == 0)
                .ToList();
        }

        public void InitializeParameters(Doctor doctor, List<DoctorsSchedule> schedules)
        {
            _doctor = doctor;
            _doctorsSchedules = schedules;
        }

        private void ApplyWorkingSchedule()
        {
            if(!IsSameTimeForAllChecked && ComboboxSelectedItem == null)
            {
                _dialogService.ShowError("Оберіть номер графіка, щоб застосувати зміну до певного графіка або оберіть \"Застосувати для усіх ...\" !","Помилка даних");
                return;
            }

            var isInputsValid = ValidateInputs();
            if (!isInputsValid)
                return;

            _startTime = DateTimeOffset.Now.Date.Add(new TimeSpan(SelectedStartHour!.Value, SelectedStartMinute!.Value, 0));
            _endTime = DateTimeOffset.Now.Date.Add(new TimeSpan(SelectedEndHour!.Value, SelectedEndMinute!.Value, 0));

            if (IsSameTimeForAllChecked)
            {
                var newSchedule = DoctorsSchedules.Select(schedule => new DoctorsSchedule{
                    NotIncrementedId = schedule.NotIncrementedId,
                    DocId = schedule.DocId,
                    BaseDate = schedule.BaseDate,
                    StartTime = _startTime,
                    EndTime = _endTime,
                }).ToList();

                DoctorsSchedules = newSchedule;
            }
            else
            {              
                var newSchedule = DoctorsSchedules.Select(schedule => new DoctorsSchedule
                {
                    NotIncrementedId = schedule.NotIncrementedId,
                    DocId = schedule.DocId,
                    BaseDate = schedule.BaseDate,
                    StartTime = schedule.StartTime,
                    EndTime = schedule.EndTime,
                }).ToList();

                foreach (var schedule in newSchedule.Where(d => d.NotIncrementedId == ComboboxSelectedItem!.NotIncrementedId))
                {
                    schedule.StartTime = _startTime;
                    schedule.EndTime = _endTime;
                }

                DoctorsSchedules = newSchedule;
            }
        }

        private void ResetInputs()
        {
            SelectedStartHour = null;
            SelectedEndHour = null;
            SelectedStartMinute = null;
            SelectedEndMinute = null;
            ComboboxSelectedItem = null;
        }

        private async Task AddSchedule()
        {
            var res = ValidateSchedulesList();
            if (!res)
                return;

            await _doctorScheduleService.AddScheduleListAsync(DoctorsSchedules);
        } 

        private bool ValidateInputs()
        {
            if(!SelectedStartHour.HasValue|| !SelectedStartMinute.HasValue)
            {
                _dialogService.ShowError("Поле з початковим часом зміни не може бути пустим!\nОберіть час з випадаючих списків", "Помилка даних");
                return false;
            }
            if (!SelectedEndHour.HasValue || !SelectedEndMinute.HasValue)
            {
                _dialogService.ShowError("Поле з кінцевим часом зміни не може бути пустим !\nОберіть час з випадаючих списків", "Помилка даних");
                return false;
            }
            if (SelectedStartHour >= SelectedEndHour && SelectedStartMinute >= SelectedEndMinute)
            {
                _dialogService.ShowError("Час початку зміни не может бути пізніший за час кінця зміни", "Помилка даних");
                return false;
            }

            return true;
        }
        private bool ValidateSchedulesList()
        {
            if(DoctorsSchedules.Any(s => s.StartTime == default || s.EndTime == default))
            {
                _dialogService.ShowError("Перед створенням графіку необіхдно призначити робочий час для працівника на кожен день !", "Помилка даних");
                return false;
            }

            return true;
        }
    }
}
