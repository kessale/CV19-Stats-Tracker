using CV19.Infrastructure.Commands;
using CV19.Models;
using CV19.Models.Decanat;
using CV19.ViewModels.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Group = CV19.Models.Decanat.Group;

namespace CV19.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Properties

        // ObservableCollection to store groups
        public ObservableCollection<Group> Groups { get; }

        // CompositeCollection for demonstration purposes
        public object[] CompositeCollection { get; }

        // Selected value in CompositeCollection
        private object _selectedCompositeValue;

        public object SelectedCompositeValue
        {
            get => _selectedCompositeValue;
            set => Set(ref _selectedCompositeValue, value);
        }

        // SelectedGroup property
        private Group _selectedGroup;

        public Group SelectedGroup
        {
            get => _selectedGroup;
            set => Set(ref _selectedGroup, value);
        }

        // TestDataPoints for chart visualization
        private IEnumerable<DataPoint> _testDataPoints;

        public IEnumerable<DataPoint> TestDataPoints
        {
            get => _testDataPoints;
            set => Set(ref _testDataPoints, value);
        }

        // Title property for window title
        private string _title = "Covid19 statistics";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        // Status property for program status
        private string _status = "Done!";

        public string Status
        {
            get => _status;
            set => Set(ref _status, value);
        }

        #endregion

        #region Commands

        // Close application command
        public ICommand CloseApplicationCommand { get; }

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        private bool CanCloseApplicationCommandExecute(object p) => true;

        // Create new group command
        public ICommand CreateGroupCommand { get; }

        private bool CanCreateGroupCommandExecute(object p) => true;

        private void OnCreateGroupCommandExecuted(object p)
        {
            var groupMaxIndex = Groups.Count + 1;
            var newGroup = new Group
            {
                Name = $"Group {groupMaxIndex}",
                Students = new ObservableCollection<Student>()
            };
            Groups.Add(newGroup);
        }

        // Delete group command
        public ICommand DeleteGroupCommand { get; }

        private bool CanDeleteGroupCommandExecuted(object p) => p is Group group && Groups.Contains(group);

        private void OnDeleteGroupCommandExecuted(object p)
        {
            if (!(p is Group group)) return;
            var groupIndex = Groups.IndexOf(group);
            Groups.Remove(group);
            if (groupIndex < Groups.Count)
                SelectedGroup = Groups[groupIndex];
        }

        #endregion

        #region Constructor

        public MainWindowViewModel()
        {
            // Initialize commands
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            CreateGroupCommand = new LambdaCommand(OnCreateGroupCommandExecuted, CanCreateGroupCommandExecute);
            DeleteGroupCommand = new LambdaCommand(OnDeleteGroupCommandExecuted, CanDeleteGroupCommandExecuted);

            // Generate TestDataPoints for chart visualization
            var dataPoints = new List<DataPoint>((int)(360 / 0.1));
            for (var x = 0d; x <= 360; x += 0.1)
            {
                const double toRad = Math.PI / 180;
                var y = Math.Sin(x * toRad);
                dataPoints.Add(new DataPoint { XValue = x, YValue = y });
            }

            TestDataPoints = dataPoints;

            // Generate test students
            var studentIndex = 1;
            var students = Enumerable.Range(1, 10).Select(i => new Student
            {
                Name = $"Name {studentIndex}",
                Surname = $"Surname {studentIndex}",
                Patronymic = $"Patronymic {studentIndex++}",
                Birthday = DateTime.Now,
                Rating = 0
            });

            // Generate test groups
            var groups = Enumerable.Range(1, 20).Select(i => new Group
            {
                Name = $"Group {i}",
                Students = new ObservableCollection<Student>(students)
            });

            // Initialize Groups ObservableCollection
            Groups = new ObservableCollection<Group>(groups);

            // Create CompositeCollection for demonstration purposes
            var dataList = new List<object>
            {
                "Hello World!",
                69,
                Groups[1],
                Groups[1].Students[0]
            };

            CompositeCollection = dataList.ToArray();
        }

        #endregion
    }
}
