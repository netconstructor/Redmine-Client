﻿namespace Redmine.Client.Ui.Models
{
    using System;
    using System.Collections.ObjectModel;

    using GalaSoft.MvvmLight;

    using Redmine.Client.Logic.Domain;
    using Redmine.Client.Logic.Services;
    using Redmine.Client.Ui.Pages;

    /// <summary>
    /// View model for <see cref="ProjectDetails"/> view.
    /// </summary>
    public class ProjectDetailsViewModel : ViewModelBase
    {
        private readonly IIssuesService issuesService;
        private ObservableCollection<Issue> issues;

        /// <summary>
        /// Initializes a new instance of the ViewModelBase class.
        /// </summary>
        /// <param name="issuesService">
        /// The issues service.
        /// </param>
        public ProjectDetailsViewModel(IIssuesService issuesService)
        {
            this.issuesService = issuesService;
            this.issues = new ObservableCollection<Issue>();
        }
        
        /// <summary>
        /// Gets or sets the projects.
        /// </summary>
        public ObservableCollection<Issue> Issues
        {
            get
            {
                return this.issues;
            }

            set
            {
                this.issues = value;
                this.RaisePropertyChanged("Issues");
            }
        }

        /// <summary>
        /// Initializes the view model.
        /// </summary>
        /// <param name="project">The project.</param>
        public void Initialize(Project project)
        {
            this.issuesService.Get(project.Id)
                .Subscribe(issue => Issues.Add(issue));
        }
    }
}