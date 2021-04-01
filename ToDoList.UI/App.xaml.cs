﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Services;
using ToDoList.Infra.Migrations;

namespace ToDoList.UI
{
    /// <summary>
    /// Interação lógica para App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly MigrationService _service;

        public App()
        {
            _service = new MigrationService();

            var migrations = new List<IMigration>()
            {
                new CriarBanco()
            };

            _service.ExecutarMigrations(migrations);
        }
    }
}