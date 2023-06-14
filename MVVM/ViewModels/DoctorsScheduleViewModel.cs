using HealthHub.MVVM.Commands;
using HealthHub.MVVM.Models.Doctors;
using HealthHub.MVVM.Views;
using HealthHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HealthHub.MVVM.ViewModels
{
    public class DoctorsScheduleViewModel : ViewModel
    {
        private readonly IDoctorScheduleService _doctorScheduleService;
        private readonly IDialogService _dialogService;
        private readonly IDoctorService _doctorService;
        private readonly DoctorsScheduleAddViewModel _doctorsScheduleAddViewModel;

        private List<DoctorsSchedule> _doctorsSchedules;
        private Doctor? _comboboxSelectedDoctor;
        private DateTime? _startTerm;
        private DateTime? _endTerm;
        private bool _isFilter1Checked;
        private bool _isAddButtonEnabled;
        private List<Doctor> _doctors;

        public List<DoctorsSchedule> DoctorsSchedules 
        { 
            get => _doctorsSchedules;
            set
            {
                _doctorsSchedules = value;
                OnPropertyChanged(nameof(DoctorsSchedules));
            }
        }
        public Doctor? ComboboxSelectedDoctor 
        { 
            get => _comboboxSelectedDoctor;
            set
            {
                _comboboxSelectedDoctor = value;

                OnPropertyChanged(nameof(ComboboxSelectedDoctor));
            }
        }
        public DateTime? StartTerm 
        { 
            get => _startTerm;
            set
            {
                _startTerm = value;
                OnPropertyChanged(nameof(StartTerm));

            }
        }
        public DateTime? EndTerm 
        { 
            get => _endTerm;
            set
            {
                _endTerm = value;
                OnPropertyChanged(nameof(EndTerm));
            }
        }
        public bool IsFilter1Checked
        {
            get => _isFilter1Checked;
            set
            {              
                _isFilter1Checked = value;
                IsAddButtonEnabled = !value;
                OnPropertyChanged(nameof(IsFilter1Checked));
            }
        }
        public bool IsAddButtonEnabled
        {
            get => _isAddButtonEnabled;
            set
            {
                _isAddButtonEnabled = value;
                OnPropertyChanged(nameof(IsAddButtonEnabled));
            }
        }
        public List<Doctor> Doctors 
        {
            get => _doctors;
            set
            {
                _doctors = value;
                OnPropertyChanged(nameof(Doctors));
            } 
        }

        public ICommand InitListCommand { get; } 
        public ICommand AddScheduleCommand { get; } 
        public ICommand ResetInputsCommand { get; } 

        public DoctorsScheduleViewModel(IDoctorScheduleService doctorScheduleService, IDialogService dialogService, IDoctorService doctorService,
            DoctorsScheduleAddViewModel doctorsScheduleAddViewModel)
        {
            _doctorScheduleService = doctorScheduleService;
            _dialogService = dialogService;
            _doctorService = doctorService;
            _doctorsScheduleAddViewModel = doctorsScheduleAddViewModel;

            InitListCommand = new RelayCommand(async exec => await InitListAsync());
            ResetInputsCommand = new RelayCommand(exec => ResetInputsValue());

            InitListCommand.Execute(null);
        }

        private async Task InitListAsync()
        {
            if (!IsFilter1Checked)
                DoctorsSchedules = await _doctorScheduleService.GetAllSchedulesAsync();
            else
            {
                var res = ValidateInputs();
                if (!res)
                    return;

                if(ComboboxSelectedDoctor != null)
                    DoctorsSchedules = await _doctorScheduleService.GetSchedulesByDocNDateAsync(ComboboxSelectedDoctor.DocId, StartTerm, EndTerm);
                else
                    DoctorsSchedules = await _doctorScheduleService.GetSchedulesByDocNDateAsync(null, StartTerm, EndTerm);

            }

            Doctors = await _doctorService.GetAllDoctorsAsync();
        }

        private async Task AddSheduleAsync()
        {
            var res = ValidateInputs();
            if (!res)
                return;

            _doctorsScheduleAddViewModel.InitializeParameters(ComboboxSelectedDoctor!, DoctorsSchedules);
            var addWindow = new DoctorsScheduleAddWindw { DataContext = _doctorsScheduleAddViewModel };
            addWindow.ShowDialog();
        }

        private bool ValidateInputs()
        {
            if (StartTerm.HasValue && EndTerm.HasValue && StartTerm > EndTerm)
            {
                _dialogService.ShowError("Початковa дата прийому не може бути більша за кінцеву дату приймоу !", "Помилка даних");
                return false;
            }
            if (!IsFilter1Checked)
            {
                if (ComboboxSelectedDoctor == null)
                {
                    _dialogService.ShowError("Для створення графіку необхідно обрати доктора з випадаючого списку!", "Помилка даних");
                    return false;
                }
                if(!StartTerm.HasValue)
                {
                    _dialogService.ShowError("Початковий день прийому обов'язково має бути зазначений, у полі \"Дні прийому з\" !", "Помилка даних");
                    return false;
                }
                if (StartTerm <= DateTime.Now.Date)
                {
                    _dialogService.ShowError("Початковий день прийому не може бути минулою датой та сьогоднішньою, у полі \"Дні прийому з\" !", "Помилка даних");
                    return false;
                }
            }
            else
            {
                if(ComboboxSelectedDoctor == null && !StartTerm.HasValue)
                {
                    _dialogService.ShowError("При активованому фільтрі хоча б одне з полей \"Лікар\" або \"Дні прийому з\" має бути заповненим!", "Помилка даних");
                    return false;
                }               
            }
            

            return true;        
        }

        private void ResetInputsValue()
        {
            ComboboxSelectedDoctor = null;
            StartTerm = null;
            EndTerm = null;
        }
    }
}
