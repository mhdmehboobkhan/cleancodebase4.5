using FluentMigrator;
using Nop.Data.Mapping;
using Nop.Data.Extensions;
using System.Collections.Generic;
using Nop.Core.Domain.Localization;
using System.Linq;
using Nop.Core.Domain.Configuration;
using Nop.Core.Domain.Messages;
using System;
using System.Threading.Tasks;
using Nop.Core.Domain.Logging;
using Nop.Core.Domain.Security;
using System.Data.SqlClient;
using Nop.Core.Domain.Customers;

namespace Nop.Data.Migrations.CustomMigrations
{
    [NopMigration("2022-07-15 03:55:08:9037680", "SchemaMigration2022_06", MigrationProcessType.NoMatter)]
    public class SchemaMigration2022_06 : MigrationBase
    {
        #region Fields

        private readonly IMigrationManager _migrationManager;
        private readonly INopDataProvider _dataProvider;

        #endregion

        #region Ctor

        public SchemaMigration2022_06(IMigrationManager migrationManager,
            INopDataProvider dataProvider)
        {
            _migrationManager = migrationManager;
            _dataProvider = dataProvider;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Run new table queires
        /// </summary>
        protected virtual void RunNewTableQueries()
        {
            if (!Schema.Table(NameCompatibilityManager.GetTableName(typeof(CustomerNote))).Exists())
                Create.TableFor<CustomerNote>();
        }

        /// <summary>
        /// Run locales queires
        /// </summary>
        protected virtual void RunLocalesQueries()
        {
            var resources = new Dictionary<string, string>();
            var languages = _dataProvider.QueryAsync<Language>($"Select * from {nameof(Language)}").Result;

            var localeStringResource = _dataProvider.QueryAsync<int>
                ($"Select count(id) from {nameof(LocaleStringResource)} Where {nameof(LocaleStringResource.ResourceName)} = 'account.dashboard'").Result;
            if (localeStringResource.FirstOrDefault() == 0)
            {
                resources.Add("account.dashboard", "Dashboard");
            }
            localeStringResource = _dataProvider.QueryAsync<int>
                ($"Select count(id) from {nameof(LocaleStringResource)} Where {nameof(LocaleStringResource.ResourceName)} = 'Admin.Customers.Customers.Choose'").Result;
            if (localeStringResource.FirstOrDefault() == 0)
            {
                resources.Add("Admin.Customers.Customers.Choose", "Choose");
                resources.Add("Admin.Customers.Customers.Choose.Title", "Choose customer");
            }
            localeStringResource = _dataProvider.QueryAsync<int>
            ($"Select count(id) from {nameof(LocaleStringResource)} Where {nameof(LocaleStringResource.ResourceName)} = 'Admin.Customers.CustomerNotes'").Result;
            if (localeStringResource.FirstOrDefault() == 0)
            {
                resources.Add("Admin.Customers.CustomerNotes", "Customer notes");
                resources.Add("Admin.Customers.CustomerNotes.addbutton", "Add note");
                resources.Add("Admin.Customers.CustomerNotes.addtitle", "Add note");


                resources.Add("Admin.Customers.CustomerNotes.List.Customer", "Customer");
                resources.Add("Admin.Customers.CustomerNotes.List.Customer.hint", "Search by customer.");
                resources.Add("Admin.Customers.CustomerNotes.List.CreatedOnFrom", "From date");
                resources.Add("Admin.Customers.CustomerNotes.List.CreatedOnFrom.hint", "Search by from date.");
                resources.Add("Admin.Customers.CustomerNotes.List.CreatedOnTo", "To date");
                resources.Add("Admin.Customers.CustomerNotes.List.CreatedOnTo.hint", "Search by to date.");

                resources.Add("Admin.Customers.CustomerNotes.fields.createdon", "Created on");
                resources.Add("Admin.Customers.CustomerNotes.fields.displaytocustomer", "Display to customer");
                resources.Add("Admin.Customers.CustomerNotes.fields.displaytocustomer.hint", "A value indicating whether to display this customer note to a customer.");
                resources.Add("Admin.Customers.CustomerNotes.fields.download", "Attached file");
                resources.Add("Admin.Customers.CustomerNotes.fields.download.hasdownload", "(check to upload file)");
                resources.Add("Admin.Customers.CustomerNotes.fields.download.hint", "Upload a file attached to this note.");
                resources.Add("Admin.Customers.CustomerNotes.fields.download.link", "Download");
                resources.Add("Admin.Customers.CustomerNotes.fields.download.link.no", "No file attached");
                resources.Add("Admin.Customers.CustomerNotes.fields.note", "Note");
                resources.Add("Admin.Customers.CustomerNotes.fields.note.hint", "Enter this note message.");
                resources.Add("Admin.Customers.CustomerNotes.fields.note.validation", "Note can not be empty.");
            }

            localeStringResource = _dataProvider.QueryAsync<int>
                ($"Select count(id) from {nameof(LocaleStringResource)} Where {nameof(LocaleStringResource.ResourceName)} = 'Admin.Customers.CustomerNotes.Fields.AddedByAdmin'").Result;
            if (localeStringResource.FirstOrDefault() == 0)
            {
                resources.Add("Admin.Customers.CustomerNotes.Fields.AddedByAdmin", "Added by admin");
            }

            localeStringResource = _dataProvider.QueryAsync<int>
                ($"Select count(id) from {nameof(LocaleStringResource)} Where {nameof(LocaleStringResource.ResourceName)} = 'Admin.Customers.CustomerNotes.Fields.Customer'").Result;
            if (localeStringResource.FirstOrDefault() == 0)
            {
                resources.Add("Admin.Customers.CustomerNotes.Fields.Customer", "Customer");
                resources.Add("Admin.Customers.CustomerNotes.Fields.Customer.hint", "Choose the customer to send note");
            }

            localeStringResource = _dataProvider.QueryAsync<int>
                ($"Select count(id) from {nameof(LocaleStringResource)} Where {nameof(LocaleStringResource.ResourceName)} = 'Admin.Customers.Customers.Notes'").Result;
            if (localeStringResource.FirstOrDefault() == 0)
            {
                resources.Add("Admin.Customers.Customers.Notes", "Notes");
            }

            localeStringResource = _dataProvider.QueryAsync<int>
                ($"Select count(id) from {nameof(LocaleStringResource)} Where {nameof(LocaleStringResource.ResourceName)} = 'Account.CustomerNotes'").Result;
            if (localeStringResource.FirstOrDefault() == 0)
            {
                resources.Add("Account.CustomerNotes", "Notes");
            }






            //insert new locale resources
            var locales = languages.SelectMany(language => resources.Select(resource => new LocaleStringResource
            {
                LanguageId = language.Id,
                ResourceName = resource.Key,
                ResourceValue = resource.Value
            })).ToList();

            foreach (var res in locales)
                _dataProvider.InsertEntityAsync(res);

            string[] updateresources = {
                "Update  LocaleStringResource set ResourceValue='Working days' where ResourceName='Admin.Test' and LanguageId = 1",
            };
            foreach (var res in updateresources)
            {
                _dataProvider.ExecuteNonQueryAsync(res);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Collect the UP migration expressions
        /// </summary>
        public override void Up()
        {
            RunNewTableQueries();

            RunLocalesQueries();

            #region Message templates

            var messageTemplate = _dataProvider.QueryAsync<int>
                ($"Select count(id) from {nameof(MessageTemplate)} Where {nameof(MessageTemplate.Name)} = '{MessageTemplateSystemNames.NewCustomerNoteAddedCustomerNotification}'").Result;
            if (messageTemplate.FirstOrDefault() == 0)
            {
                var template = new MessageTemplate
                {
                    Name = MessageTemplateSystemNames.NewCustomerNoteAddedCustomerNotification,
                    Subject = "%Store.Name%. A new note sent to you",
                    Body = $"<p><a href=\"%Store.URL%\">%Store.Name%</a><br /><br />Hello %Customer.FullName%,<br />New note has been added to your account:<br />\"%Customer.NewNoteText%\".</p>",
                    IsActive = true,
                };
                template.Body = template.ToBasicUIStyle();
                _dataProvider.InsertEntity(template);
            }

            messageTemplate = _dataProvider.QueryAsync<int>
                ($"Select count(id) from {nameof(MessageTemplate)} Where {nameof(MessageTemplate.Name)} = '{MessageTemplateSystemNames.NewCustomerNoteAddedStoreNotification}'").Result;
            if (messageTemplate.FirstOrDefault() == 0)
            {
                var template = new MessageTemplate
                {
                    Name = MessageTemplateSystemNames.NewCustomerNoteAddedStoreNotification,
                    Subject = "%Store.Name%. a new note sent to you from %Customer.FullName%",
                    Body = "<p>Hello <a href=\"%Store.URL%\">%Store.Name%</a>,<br />A new note has been added by %Customer.FullName%:<br />\"%Customer.NewNoteText%\".</p>",
                    IsActive = true,
                };
                template.Body = template.ToBasicUIStyle();
                _dataProvider.InsertEntity(template);
            }

            #endregion
        }

        public override void Down()
        {
            //add the downgrade logic if necessary 
        }

        #endregion
    }
}
