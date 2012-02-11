﻿namespace Redmine.Client.Ui.Common
{
    using System.Collections.Generic;
    using System.IO.IsolatedStorage;

    /// <summary>
    /// Manages the application settings.
    /// </summary>
    public class ApplicationSettingsManager : IApplicationSettingsManager
    {
        /// <summary>
        /// Gets the isolated storage settings.
        /// </summary>
        private IsolatedStorageSettings Storage
        {
            get
            {
                return IsolatedStorageSettings.ApplicationSettings;
            }
        }

        /// <summary>
        /// Gets Redmine client credentials class.
        /// </summary>
        /// <returns>
        /// The instance of <see cref="ConnectionSettings"/>
        /// </returns>
        public ConnectionSettings GetConnectionSettings()
        {
            if (Storage.Contains("ConnectionSettings"))
            {
                var storage = (ConnectionSettings)Storage["ConnectionSettings"];
                return storage;
            }

            return new ConnectionSettings { AuthenticationRequired = false, Url = @"http://www.redmine.org" };
        }
        
        /// <summary>
        /// Sets the application network credentials.
        /// </summary>
        /// <param name="credentials">
        /// The credentials.
        /// </param>
        public void SetConnectionSettings(ConnectionSettings credentials)
        {
            IsolatedStorageSettings.ApplicationSettings["ConnectionSettings"] = credentials;
        }
    }
}