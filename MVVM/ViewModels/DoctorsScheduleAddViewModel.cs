using HealthHub.MVVM.Models.Doctors;
using HealthHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.ViewModels
{
    public class DoctorsScheduleAddViewModel : ViewModel
    {
        private readonly IDialogService _dialogService;
        private readonly IDoctorScheduleService _doctorScheduleService;

        private Doctor _doctor;
        private DoctorsSchedule _comboboxSelectedItem;
        private List<DoctorsSchedule> _doctorsSchedules;
        private DateTimeOffset _startTime;
        private DateTimeOffset _endTime;

        public Doctor Doctor
        {
            get => _doctor;
        }

        public DoctorsSchedule ComboboxSelectedItem
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
        public DateTimeOffset StartTime
        {
            get => _startTime;
            set
            {
                _startTime = value;
                OnPropertyChanged(nameof(StartTime));
            }
        }
        public DateTimeOffset EndTime
        {
            get => _endTime;
            set
            {
                _endTime = value;
                OnPropertyChanged(nameof(EndTime));
            }
        }

        public DoctorsScheduleAddViewModel(IDialogService dialogService, IDoctorScheduleService doctorScheduleService)
        {
            _dialogService = dialogService;
            _doctorScheduleService = doctorScheduleService;
        }

        public void InitializeParameters(Doctor doctor, List<DoctorsSchedule> schedules)
        {
            _doctor = doctor;
            _doctorsSchedules = schedules;
        }
    }
}
