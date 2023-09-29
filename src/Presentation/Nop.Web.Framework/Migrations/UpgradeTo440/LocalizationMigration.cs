﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FluentMigrator;
using Nop.Core.Infrastructure;
using Nop.Data;
using Nop.Data.Migrations;
using Nop.Services.Common;
using Nop.Services.Localization;

namespace Nop.Web.Framework.Migrations.UpgradeTo440
{
    [NopMigration("2020-06-10 00:00:00", "4.40.0", UpdateMigrationType.Localization, MigrationProcessType.Update)]
    public class LocalizationMigration : MigrationBase
    {
        /// <summary>Collect the UP migration expressions</summary>
        public override void Up()
        {
            if (!DataSettingsManager.IsDatabaseInstalled())
                return;

            //do not use DI, because it produces exception on the installation process
            var localizationService = EngineContext.Current.Resolve<ILocalizationService>();

            //use localizationService to add, update and delete localization resources
            localizationService.DeleteLocaleResourcesAsync(new List<string>
            {
                "Account.Fields.VatNumber.Status",
                "Account.Fields.VatNumberStatus",
                "Account.PasswordRecovery.OldPassword",
                "Account.PasswordRecovery.OldPassword.Required",
                "Account.Register.Unsuccessful",
                "Account.ShoppingCart",
                "ActivityLog.AddNewWidget",
                "ActivityLog.DeleteWidget",
                "ActivityLog.EditWidget",
                "Admin.Address.Fields.StateProvince.Required",
                "Admin.Catalog.Products.ProductAttributes.Attributes.ValidationRules.ViewLink",
                "Admin.Catalog.Products.ProductAttributes.Attributes.Values.EditAttributeDetails",
                "Admin.Catalog.Products.SpecificationAttributes.NoAttributeOptions",
                "Admin.Catalog.Products.SpecificationAttributes.SelectOption",
                "Admin.Common.CancelChanges",
                "Admin.Common.Check",
                "Admin.Common.DeleteConfirmationParam",
                "Admin.Common.List",
                "Admin.Common.LoseUnsavedChanges",
                "Admin.Common.SaveChanges",
                "Admin.Configuration.Currencies.Localization",
                "Admin.Configuration.Currencies.Select",
                "Admin.Configuration.EmailAccounts.Fields.SendTestEmailTo.Button",
                "Admin.Configuration.PaymentMethods",
                "Admin.Configuration.PaymentMethodsAndRestrictions",
                "Admin.Configuration.Settings.CustomerUser.BlockTitle.DefaultFields",
                "Admin.Configuration.Settings.CustomerUser.BlockTitle.ExternalAuthentication",
                "Admin.Configuration.Settings.CustomerUser.BlockTitle.TimeZone",
                "Admin.Configuration.Settings.CustomerUser.CustomerSettings",
                "Admin.Configuration.Settings.Order.OrderSettings",
                "Admin.Configuration.Settings.ProductEditor.BlockTitle.LinkedProducts",
                "Admin.Configuration.Settings.ProductEditor.Id",
                "Admin.Configuration.SMSProviders",
                "Admin.Configuration.SMSProviders.BackToList",
                "Admin.Configuration.SMSProviders.Configure",
                "Admin.Configuration.SMSProviders.Fields.FriendlyName",
                "Admin.Configuration.SMSProviders.Fields.IsActive",
                "Admin.Configuration.SMSProviders.Fields.SystemName",
                "Admin.ContentManagement.Topics.Fields.Store.AllStores",
                "Admin.ContentManagement.Widgets.ChooseZone",
                "Admin.ContentManagement.Widgets.ChooseZone.Hint",
                "Admin.Customers.Customers.Fields.Email.Required",
                "Admin.Customers.Customers.Fields.FirstName.Required",
                "Admin.Customers.Customers.Fields.LastName.Required",
                "Admin.Customers.Customers.Fields.SystemName",
                "Admin.Customers.Customers.Fields.SystemName.Hint",
                "Admin.Customers.Customers.Fields.Username.Required",
                "Admin.Customers.Customers.RewardPoints.Alert.HistoryAdd",
                "Admin.DT.Processing",
                "Admin.NopCommerceNews.HideAdv",
                "Admin.NopCommerceNews.ShowAdv",
                "Admin.Orders.OrderNotes.Alert.Add",
                "Admin.System.QueuedEmails.Fields.Priority.Required",
                "Common.DeleteConfirmationParam",
                "Common.Extensions.RelativeFormat",
                "Common.Home",
                "EUCookieLaw.CannotBrowse",
                "EUCookieLaw.Title",
                "Filtering.FilterResults",
                "Forum.Replies.Count",
                "Forum.Topics.Count",
                "News.Archive",
                "Newsletter.ResultAlreadyDeactivated",
                "PageTitle.EmailRevalidation",
                "PDFInvoice.CreatedOn",
                "PDFInvoice.Note",
                "PrivateMessages.Send.Subject.Required",
                "PrivateMessages.Sent.DateColumn",
                "PrivateMessages.Sent.DeleteSelected",
                "PrivateMessages.Sent.SubjectColumn",
                "PrivateMessages.Sent.ToColumn",
                "Profile.FullName",
                "RewardPoints.Message.Expired",
                "ShoppingCart.AddToWishlist.Update",
                "ShoppingCart.UpdateCartItem",
                "Tax.SelectType",
                "Admin.Configuration.Settings.GeneralCommon.BlockTitle.FullText",
                "Admin.Configuration.Settings.GeneralCommon.FullTextSettings.CurrenlyDisabled",
                "Admin.Configuration.Settings.GeneralCommon.FullTextSettings.CurrenlyEnabled",
                "Admin.Configuration.Settings.GeneralCommon.FullTextSettings.Disable",
                "Admin.Configuration.Settings.GeneralCommon.FullTextSettings.Disabled",
                "Admin.Configuration.Settings.GeneralCommon.FullTextSettings.Enable",
                "Admin.Configuration.Settings.GeneralCommon.FullTextSettings.Enabled",
                "Admin.Configuration.Settings.GeneralCommon.FullTextSettings.NoiseWords",
                "Admin.Configuration.Settings.GeneralCommon.FullTextSettings.NotSupported",
                "Admin.Configuration.Settings.GeneralCommon.FullTextSettings.SearchMode",
                "Admin.Configuration.Settings.GeneralCommon.FullTextSettings.SearchMode.Hint",
                "Admin.Configuration.Settings.GeneralCommon.FullTextSettings.Supported",
                "Enums.Nop.Core.Domain.Common.FulltextSearchMode.And",
                "Enums.Nop.Core.Domain.Common.FulltextSearchMode.ExactMatch",
                "Enums.Nop.Core.Domain.Common.FulltextSearchMode.Or",
                "Admin.System.SystemInfo.UseRedisForCaching",
                "Admin.System.SystemInfo.UseRedisForCaching.Hint",
                "Admin.Configuration.AppSettings.Redis",
                "Admin.Configuration.AppSettings.Redis.Enabled",
                "Admin.Configuration.AppSettings.Redis.Enabled.Hint",
                "Admin.Configuration.AppSettings.Redis.ConnectionString",
                "Admin.Configuration.AppSettings.Redis.ConnectionString.Hint",
                "Admin.Configuration.AppSettings.Redis.DatabaseId",
                "Admin.Configuration.AppSettings.Redis.DatabaseId.Hint",
                "Admin.Configuration.AppSettings.Redis.UseCaching",
                "Admin.Configuration.AppSettings.Redis.UseCaching.Hint",
                "Admin.Configuration.AppSettings.Redis.StoreDataProtectionKeys",
                "Admin.Configuration.AppSettings.Redis.StoreDataProtectionKeys.Hint",
                "Admin.Configuration.AppSettings.Redis.StorePluginsInfo",
                "Admin.Configuration.AppSettings.Redis.StorePluginsInfo.Hint",
                "Admin.Configuration.AppSettings.Redis.IgnoreTimeoutException",
                "Admin.Configuration.AppSettings.Redis.IgnoreTimeoutException.Hint",
                "Admin.System.SystemInfo.RedisEnabled",
                "Admin.System.SystemInfo.RedisEnabled.Hint",
                "Admin.System.SystemInfo.UseRedisToStoreDataProtectionKeys",
                "Admin.System.SystemInfo.UseRedisToStoreDataProtectionKeys.Hint",
                "Admin.System.SystemInfo.UseRedisToStorePluginsInfo",
                "Admin.System.SystemInfo.UseRedisToStorePluginsInfo.Hint",
                "Filtering.PriceRangeFilter.Under",
                "Filtering.PriceRangeFilter.Over",
                "Filtering.PriceRangeFilter.Remove",
                "Filtering.SpecificationFilter.CurrentlyFilteredBy",
                "Filtering.SpecificationFilter.Remove",
                "Filtering.SpecificationFilter.Separator",
            }).Wait();

            var languageService = EngineContext.Current.Resolve<ILanguageService>();
            var languages = languageService.GetAllLanguagesAsync(true).Result;
            var languageId = languages
                .Where(lang => lang.UniqueSeoCode == new CultureInfo(NopCommonDefaults.DefaultLanguageCulture).TwoLetterISOLanguageName)
                .Select(lang => lang.Id).FirstOrDefault();
            
            localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
            {
                ["Admin.System.Warnings.PluginNotEnabled.AutoFixAndRestart"] = "Uninstall and delete all not used plugins automatically (site will be restarted)",
                ["Admin.Configuration.AppSettings"] = "App settings",
                ["Admin.Configuration.AppSettings.Cache"] = "Cache configuration",
                ["Admin.Configuration.AppSettings.Cache.DefaultCacheTime"] = "Default cache time",
                ["Admin.Configuration.AppSettings.Cache.DefaultCacheTime.Hint"] = "Set default cache time (in minutes).",
                ["Admin.Configuration.AppSettings.Cache.ShortTermCacheTime"] = "Short term cache time",
                ["Admin.Configuration.AppSettings.Cache.ShortTermCacheTime.Hint"] = "Set short term cache time (in minutes).",
                ["Admin.Configuration.AppSettings.Cache.BundledFilesCacheTime"] = "Bundled files cache time",
                ["Admin.Configuration.AppSettings.Cache.BundledFilesCacheTime.Hint"] = "Set bundled files cache time (in minutes).",
                ["Admin.Configuration.AppSettings.Hosting"] = "Hosting configuration",
                ["Admin.Configuration.AppSettings.Hosting.UseHttpClusterHttps"] = "Use HTTP_CLUSTER_HTTPS",
                ["Admin.Configuration.AppSettings.Hosting.UseHttpClusterHttps.Hint"] = "Enable this setting if your hosting uses a load balancer. It'll be used to determine whether the current request is HTTPS.",
                ["Admin.Configuration.AppSettings.Hosting.UseHttpXForwardedProto"] = "Use HTTP_X_FORWARDED_PROTO",
                ["Admin.Configuration.AppSettings.Hosting.UseHttpXForwardedProto.Hint"] = "Enable this setting if you use a reverse proxy server (for example, if you host your site on Linux with Nginx/Apache and SSL).",
                ["Admin.Configuration.AppSettings.Hosting.ForwardedHttpHeader"] = "Forwarded HTTP header",
                ["Admin.Configuration.AppSettings.Hosting.ForwardedHttpHeader.Hint"] = "Use this setting if your hosting doesn't use 'X-FORWARDED-FOR' header to determine IP address. You can specify a custom HTTP header (e.g. CF-Connecting-IP, X-FORWARDED-PROTO, etc).",
                ["Admin.Configuration.AppSettings.AzureBlob"] = "Azure Blob storage configuration",
                ["Admin.Configuration.AppSettings.AzureBlob.ConnectionString"] = "Connection string",
                ["Admin.Configuration.AppSettings.AzureBlob.ConnectionString.Hint"] = "Specify the connection string for Azure Blob storage.",
                ["Admin.Configuration.AppSettings.AzureBlob.ContainerName"] = "Container name",
                ["Admin.Configuration.AppSettings.AzureBlob.ContainerName.Hint"] = "Specify the container name for Azure Blob storage.",
                ["Admin.Configuration.AppSettings.AzureBlob.EndPoint"] = "Endpoint",
                ["Admin.Configuration.AppSettings.AzureBlob.EndPoint.Hint"] = "Specify the endpoint for Azure Blob storage.",
                ["Admin.Configuration.AppSettings.AzureBlob.AppendContainerName"] = "Append container name",
                ["Admin.Configuration.AppSettings.AzureBlob.AppendContainerName.Hint"] = "Enable this setting to append the endpoint with the container name when constructing the URL.",
                ["Admin.Configuration.AppSettings.AzureBlob.StoreDataProtectionKeys"] = "Store Data Protection keys",
                ["Admin.Configuration.AppSettings.AzureBlob.StoreDataProtectionKeys.Hint"] = "Enable this setting to store the Data Protection keys in Azure Blob Storage.",
                ["Admin.Configuration.AppSettings.AzureBlob.DataProtectionKeysContainerName"] = "Container name for Data Protection keys",
                ["Admin.Configuration.AppSettings.AzureBlob.DataProtectionKeysContainerName.Hint"] = "Specify the container name for the Data Protection keys. This should be a private container separate from the Blob container used for media storage.",
                ["Admin.Configuration.AppSettings.AzureBlob.DataProtectionKeysVaultId"] = "Key vault ID",
                ["Admin.Configuration.AppSettings.AzureBlob.DataProtectionKeysVaultId.Hint"] = "Specify the Azure key vault ID used to encrypt the Data Protection keys.",
                ["Admin.Configuration.AppSettings.Installation"] = "Installation configuration",
                ["Admin.Configuration.AppSettings.Installation.DisableSampleData"] = "Disable sample data",
                ["Admin.Configuration.AppSettings.Installation.DisableSampleData.Hint"] = "Enable this setting to disable sample data for installation.",
                ["Admin.Configuration.AppSettings.Installation.DisabledPlugins"] = "Disabled plugins",
                ["Admin.Configuration.AppSettings.Installation.DisabledPlugins.Hint"] = "Specify a list of plugins (comma separated) ignored during installation.",
                ["Admin.Configuration.AppSettings.Plugin"] = "Plugin configuration",
                ["Admin.Configuration.AppSettings.Plugin.ClearPluginShadowDirectoryOnStartup"] = "Clear plugin shadow directory on startup",
                ["Admin.Configuration.AppSettings.Plugin.ClearPluginShadowDirectoryOnStartup.Hint"] = "Enable this setting to clear the plugin shadow directory (/Plugins/bin) on application startup.",
                ["Admin.Configuration.AppSettings.Plugin.CopyLockedPluginAssembilesToSubdirectoriesOnStartup"] = "Copy locked plugins to subdirectories on startup",
                ["Admin.Configuration.AppSettings.Plugin.CopyLockedPluginAssembilesToSubdirectoriesOnStartup.Hint"] = "Enable this setting to copy 'locked' assemblies from the plugin shadow directory (/Plugins/bin) to temporary subdirectories on application startup.",
                ["Admin.Configuration.AppSettings.Plugin.UseUnsafeLoadAssembly"] = "Use unsafe load assembly",
                ["Admin.Configuration.AppSettings.Plugin.UseUnsafeLoadAssembly.Hint"] = "Enable this setting to load an assembly into the load-from context, bypassing some security checks.",
                ["Admin.Configuration.AppSettings.Plugin.UsePluginsShadowCopy"] = "Use plugins shadow copy",
                ["Admin.Configuration.AppSettings.Plugin.UsePluginsShadowCopy.Hint"] = "Enable this setting to copy plugins to the shadow directory (/Plugins/bin) on application startup.",
                ["Admin.Configuration.AppSettings.Common"] = "Common configuration",
                ["Admin.Configuration.AppSettings.Common.DisplayFullErrorStack"] = "Display full error",
                ["Admin.Configuration.AppSettings.Common.DisplayFullErrorStack.Hint"] = "Enable this setting to display the full error in production environment. It's ignored (always enabled) in development environment.",
                ["Admin.Configuration.AppSettings.Common.MiniProfilerEnabled"] = "Enable MiniProfiler",
                ["Admin.Configuration.AppSettings.Common.MiniProfilerEnabled.Hint"] = "Enable this setting to display the performance indicator by MiniProfiler. By default, the performance indicator can see only Administrators, to change this behavior set ACL rules in the admin area.",
                ["Admin.Configuration.AppSettings.Common.UserAgentStringsPath"] = "User agent strings path",
                ["Admin.Configuration.AppSettings.Common.UserAgentStringsPath.Hint"] = "Specify a path to the file with user agent strings.",
                ["Admin.Configuration.AppSettings.Common.CrawlerOnlyUserAgentStringsPath"] = "Crawler user agent strings path",
                ["Admin.Configuration.AppSettings.Common.CrawlerOnlyUserAgentStringsPath.Hint"] = "Specify a path to the file with crawler only user agent strings. Leave empty to always use full version of user agent strings file.",
                ["Admin.Configuration.AppSettings.Common.UseSessionStateTempDataProvider"] = "Use session state for TempData",
                ["Admin.Configuration.AppSettings.Common.UseSessionStateTempDataProvider.Hint"] = "Enable this setting to store TempData in the session state. By default the cookie-based TempData provider is used to store TempData in cookies.",
                ["ActivityLog.AddNewSpecAttributeGroup"] = "Added a new specification attribute group ('{0}')",
                ["ActivityLog.EditSpecAttributeGroup"] = "Edited a specification attribute group ('{0}')",
                ["ActivityLog.DeleteSpecAttributeGroup"] = "Deleted a specification attribute group ('{0}')",
                ["Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Buttons.AddNew"] = "Add attribute",
                ["Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Buttons.DeleteSelected"] = "Delete attributes (selected)",
                ["Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Fields.SpecificationAttributeGroup"] = "Group",
                ["Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Fields.SpecificationAttributeGroup.Hint"] = "The group of the specification attribute.",
                ["Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Fields.SpecificationAttributeGroup.None"] = "None",
                ["Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttributeGroup.Added"] = "The new attribute group has been added successfully.",
                ["Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttributeGroup.AddNew"] = "Add a new specification attribute group",
                ["Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttributeGroup.BackToList"] = "back to specification attribute list",
                ["Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttributeGroup.Buttons.AddNew"] = "Add group",
                ["Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttributeGroup.DefaultGroupName"] = "Default group (non-grouped specification attributes)",
                ["Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttributeGroup.Deleted"] = "The attribute group has been deleted successfully.",
                ["Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttributeGroup.EditAttributeGroupDetails"] = "Edit specification attribute group details",
                ["Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttributeGroup.Fields.DisplayOrder"] = "Display order",
                ["Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttributeGroup.Fields.DisplayOrder.Hint"] = "The display order of the specification attribute group.",
                ["Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttributeGroup.Fields.Name"] = "Name",
                ["Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttributeGroup.Fields.Name.Hint"] = "The name of the specification attribute group.",
                ["Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttributeGroup.Fields.Name.Required"] = "Please provide a name.",
                ["Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttributeGroup.Info"] = "Attribute group info",
                ["Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttributeGroup.Updated"] = "The attribute group has been updated successfully.",
                ["Admin.Catalog.Products.SpecificationAttributes.NameFormat"] = "{0} >> {1}",
                ["Admin.System.Warnings.PluginsOverrideSameService"] = "The \"{0}\" interface/class has been overridden in those assemblies: {1}. This situation may cause errors because there is only one of them will be used (Please contact the assembly(ies) developers to solve this problem.)",

                //#475
                ["Admin.Configuration.Authentication"] = "Authentication",
                ["Admin.Configuration.Authentication.MultiFactorMethods"] = "Multi-factor authentication",
                ["Admin.Configuration.Authentication.MultiFactorMethods.BackToList"] = "back to multi-factor authentication method list",
                ["Admin.Configuration.Authentication.MultiFactorMethods.Configure"] = "Configure",
                ["Admin.Configuration.Authentication.MultiFactorMethods.Fields.DisplayOrder"] = "Display order",
                ["Admin.Configuration.Authentication.MultiFactorMethods.Fields.FriendlyName"] = "Friendly name",
                ["Admin.Configuration.Authentication.MultiFactorMethods.Fields.IsActive"] = "Is active",
                ["Admin.Configuration.Authentication.MultiFactorMethods.Fields.SystemName"] = "System name",
                ["Permission.Authentication.ManageMultifactorMethods"] = "Admin area. Manage Multi-factor Authentication Methods",
                ["MultiFactorAuthentication.Notification.SelectedMethodIsNotActive"] = "The multi-factor authentication provider specified in your account settings has been deactivated. Please contact your administrator.",
                ["PageTitle.MultiFactorAuthentication"] = "Multi-factor authentication",
                ["PageTitle.MultiFactorVerification"] = "Multi-factor verification",
                ["Account.MultiFactorAuthentication.Fields.IsEnabled"] = "Is enabled",
                ["Account.MultiFactorAuthentication.Settings"] = "Settings",
                ["Account.MultiFactorAuthentication.Providers"] = "Authentication providers",
                ["Account.MultiFactorAuthentication.Providers.NoActive"] = "No active providers",
                ["Account.MultiFactorAuthentication.Description"] = "<p>To activate multi-factor authentication for your account, you need: </p></br><ol><li>1. Activate the 'Is enabled' setting.</li><li>2. Choose one of the multi-factor authentication providers.</li><li>3. Save.</li><li>4. Configure the selected multi-factor authentication provider by following the instructions on the individual settings page of the selected provider.</li></ol></br><p> WARNING. After saving the selected provider, be sure to configure it, otherwise you will be denied access the next time you try to enter your account.</p>",
                ["Admin.Customers.Customers.Fields.MultiFactorAuthenticationProvider"] = "Multi-factor authentication provider",
                ["Admin.Customers.Customers.Fields.MultiFactorAuthenticationProvider.Hint"] = "Name of the multi-factor authentication provider to which the customer is associated.",
                ["Admin.Customers.Customers.UnbindMFAProvider"] = "The customer has unbinded from the multifactor authentication provider successfully.",

                ["Admin.Configuration.Plugins.Description.DownloadMorePlugins"] = "You can download more nopCommerce plugins in our <a href=\"{0}\" target=\"_blank\">marketplace</a>",
                ["Admin.Configuration.Payment.Methods.DownloadMorePlugins"] = "You can download more plugins in our <a href=\"{0}\" target=\"_blank\">marketplace</a>",
                ["Admin.Configuration.Tax.Providers.DownloadMorePlugins"] = "You can download more plugins in our <a href=\"{0}\" target=\"_blank\">marketplace</a>",
                ["Admin.Configuration.Settings.GeneralCommon.DefaultStoreTheme.GetMore"] = "You can get more themes in our <a href=\"{0}\" target=\"_blank\">marketplace</a>",
                ["Admin.Configuration.Plugins.OfficialFeed.Instructions"] = "Here you can find third-party extensions and themes which are developed by our community and partners. They are also available in our <a href=\"{0}\" target=\"_blank\">marketplace</a>",
                ["Admin.Catalog.Attributes.CheckoutAttributes.Values.AddNew"] = "Add a new checkout attribute value",

                ["Admin.Configuration.Settings.Catalog.OneReviewPerProductFromCustomer"] = "One review per product from customer",
                ["Admin.Configuration.Settings.Catalog.OneReviewPerProductFromCustomer.Hint"] = "Check to restrict customer to add just 1 review per product.",
                ["Reviews.AlreadyAddedProductReviews"] = "Product review is already added for this product",
                ["Admin.Configuration.Plugins.ChangesApplyAfterReboot"] = "Changes will be applied after restart application",
                ["Admin.Configuration.Plugins.Fields.IsEnabled"] = "Enabled",
                ["Admin.Customers.ActivityLog.Fields.IpAddress.Hint"] = "A customer IP address.",
                ["Plugins.Widgets.GoogleAnalytics.UseJsToSendEcommerceInfo"] = "Use JS to send eCommerce info",
                ["Plugins.Widgets.GoogleAnalytics.UseJsToSendEcommerceInfo.Hint"] = "Check to use JS code to send eCommerce info from the order completed page. But in case of redirection payment methods some customers may skip it. Otherwise, eCommerce information will be sent using HTTP request. Information is sent each time an order is paid but UTM is not supported in this mode.",
                ["Plugins.Widgets.GoogleAnalytics.IncludeCustomerId"] = "Include customer ID",
                ["Plugins.Widgets.GoogleAnalytics.IncludeCustomerId.Hint"] = "Check to include customer identifier to script.",
                ["Admin.Configuration.Plugins.DiscardChanges"] = "Discard changes",
                ["Admin.Configuration.Plugins.DiscardChanges.Progress"] = "Discarding changes on plugins...",
                ["Admin.Configuration.Plugins.ApplyChanges"] = "Restart application to apply changes",
                ["Admin.Configuration.Plugins.ApplyChanges.Progress"] = "Applying changes on plugins...",
                ["Admin.Configuration.Settings.CustomerUser.ForceMultifactorAuthentication"] = "Force multi-factor authentication",
                ["Admin.Configuration.Settings.CustomerUser.ForceMultifactorAuthentication.Hint"] = "Force activation of multi-factor authentication for all users (at least one MFA provider must be active).",
                ["Account.MultiFactorAuthentication.Warning.ForceActivation"] = "Enforce multi-factor authentication for all users is enabled.",
                ["Admin.Configuration.Settings.CustomerUser.ForceMultifactorAuthentication.Warning"] = "There are currently no active authentication providers. To use this setting, you must activate one of the multi-factor authentication providers.",

                //#1730
                ["Admin.Configuration.AppSettings.Installation.InstallRegionalResources"] = "Install regional resources",
                ["Admin.Configuration.AppSettings.Installation.InstallRegionalResources.Hint"] = "Enable this setting to download and setup the regional language pack during installation.",

                //#5213
                ["Admin.System.Log.List.PremiumSupport"] = "Have questions or need help? Get dedicated support from the nopCommerce team with a guaranteed response within 24 hours. Please find more about our premium support services <a href=\"{0}\" target=\"_blank\">here</a>.",
                ["Admin.System.Log.PremiumSupport"] = "Have questions or need help? Get dedicated support from the nopCommerce team with a guaranteed response within 24 hours. Please find more about our premium support services <a href=\"{0}\" target=\"_blank\">here</a>.",

                //#4699
                ["Admin.Configuration.AppSettings.DistributedCache"] = "Distributed cache configuration",
                ["Admin.Configuration.AppSettings.DistributedCache.ConnectionString"] = "Connection string",
                ["Admin.Configuration.AppSettings.DistributedCache.ConnectionString.Hint"] = "Specify connection string",
                ["Admin.Configuration.AppSettings.DistributedCache.DistributedCacheType"] = "Distributed cache type",
                ["Admin.Configuration.AppSettings.DistributedCache.DistributedCacheType.Hint"] = "Specify type of distributed cache",
                ["Admin.Configuration.AppSettings.DistributedCache.Enabled"] = "Use distributed cache",
                ["Admin.Configuration.AppSettings.DistributedCache.Enabled.Hint"] = "Enable this setting to use distributed cache instead of a single instance cache",
                ["Admin.Configuration.AppSettings.DistributedCache.SchemaName"] = "Schema name",
                ["Admin.Configuration.AppSettings.DistributedCache.SchemaName.Hint"] = "Specify the schema name (by default it is dbo)",
                ["Admin.Configuration.AppSettings.DistributedCache.TableName"] = "Table name",
                ["Admin.Configuration.AppSettings.DistributedCache.TableName.Hint"] = "Specify the table name",
                ["Admin.Configuration.Settings.GeneralCommon.LoadAllLocaleRecordsOnStartup.Warning"] = "It seems that you use distributed cache, keep in mind that enabling this setting creates a lot of traffic between the distributed cache server and the application because of the large number of locales",

                //configuration steps tour
                ["Admin.ConfigurationSteps"] = "Start accepting orders",
                ["Admin.ConfigurationSteps.Welcome.Title"] = "Welcome to your store!",
                ["Admin.ConfigurationSteps.Welcome.Text"] = "Can’t wait to start accepting orders? Let us show you how to set up your store fast and easy. The steps below describe the most important settings for the online shop. With our tips on each page you will see how clear this process is. You will be ready to start selling immediately after you go through these steps. So good luck!",
                ["Admin.ConfigurationSteps.PersonalizeStore.Title"] = "Personalize your store",
                ["Admin.ConfigurationSteps.PersonalizeStore.Description"] = "Choose a beautiful theme for your store and add your logo",
                ["Admin.ConfigurationSteps.AddStoreInfo.Title"] = "Add your store info",
                ["Admin.ConfigurationSteps.AddStoreInfo.Description"] = "Enter your store details and protect your customers using SSL",
                ["Admin.ConfigurationSteps.SetUpPayments.Title"] = "Set up payments",
                ["Admin.ConfigurationSteps.SetUpPayments.Description"] = "Choose how your customers will pay for their orders",
                ["Admin.ConfigurationSteps.SetUpTaxes.Title"] = "Set up taxes",
                ["Admin.ConfigurationSteps.SetUpTaxes.Description"] = "Configure rates manually or choose a tax service to automate all tax things",
                ["Admin.ConfigurationSteps.CreateProducts.Title"] = "Create products",
                ["Admin.ConfigurationSteps.CreateProducts.Description"] = "Build a catalog with attractive product descriptions and pictures",
                ["Admin.ConfigurationSteps.CreateEmailAccounts.Title"] = "Set up email accounts",
                ["Admin.ConfigurationSteps.CreateEmailAccounts.Description"] = "It allows you to send notifications to your customers",
                ["Admin.ConfigurationSteps.EditServicesInfo.Title"] = "Edit services info",
                ["Admin.ConfigurationSteps.EditServicesInfo.Description"] = "Add info pages describing shipping, return policy and more",
                ["Admin.ConfigurationSteps.PoweredBy.Title"] = "“Powered by” link",
                ["Admin.ConfigurationSteps.PoweredBy.Description"] = "Remove the “Powered by nopCommerce” link from the footer",
                ["Admin.ConfigurationSteps.Back"] = "Back",
                ["Admin.ConfigurationSteps.NextStep"] = "Next",
                ["Admin.ConfigurationSteps.NextPage"] = "Next page",
                ["Admin.ConfigurationSteps.Done"] = "Done",
                ["Admin.ConfigurationSteps.PersonalizeStore.Intro.Title"] = "Configuration tour",
                ["Admin.ConfigurationSteps.PersonalizeStore.Intro.Text"] = "Let us help you to configure your store! We will share a few tips, describing the most important fields for the initial configuration.",
                ["Admin.ConfigurationSteps.PersonalizeStore.BasicAdvanced.Title"] = "“Basic/Advanced” modes",
                ["Admin.ConfigurationSteps.PersonalizeStore.BasicAdvanced.Text"] = "This two-position <b>Basic/Advanced</b> switch allows you to switch between the page display modes. For convenience of use, the most frequent settings are shown in the Basic mode. If you cannot find a required setting on a page, switch to the Advanced mode to see all the available settings.",
                ["Admin.ConfigurationSteps.PersonalizeStore.Theme.Title"] = "Choose a theme",
                ["Admin.ConfigurationSteps.PersonalizeStore.Theme.Text"] = "On this page, you can set up your store theme. After you choose a theme on our <a href=\"{0}\" target=\"_blank\">marketplace</a>, upload it on your site following <a href=\"{1}\" target=\"_blank\">these instructions</a>. Then refresh this page, and you will see all the available themes. Choose one and click the <b>Save</b> button in the top right.",
                ["Admin.ConfigurationSteps.PersonalizeStore.Logo.Title"] = "Upload your logo",
                ["Admin.ConfigurationSteps.PersonalizeStore.Logo.Text"] = "In this field, click the <b>Upload a file</b> button, then choose your logo file.",
                ["Admin.ConfigurationSteps.EmailAccount.EmailAddress.Title"] = "Email address",
                ["Admin.ConfigurationSteps.EmailAccount.EmailAddress.Text"] = "Enter the “from” email address for all outgoing emails of your store. Example: sales@yourstore.com.",
                ["Admin.ConfigurationSteps.EmailAccount.DisplayName.Title"] = "Email display name",
                ["Admin.ConfigurationSteps.EmailAccount.DisplayName.Text"] = "Enter the displayed name for outgoing emails of your store. For example, “Your store sales department”.",
                ["Admin.ConfigurationSteps.EmailAccount.Host.Title"] = "Host",
                ["Admin.ConfigurationSteps.EmailAccount.Host.Text"] = "This is the host name or IP address of your mail server. You can normally find this out from your ISP or web host.",
                ["Admin.ConfigurationSteps.EmailAccount.Port.Title"] = "Port",
                ["Admin.ConfigurationSteps.EmailAccount.Port.Text"] = "Enter the SMTP port of your email server. This is usually port 25.",
                ["Admin.ConfigurationSteps.EmailAccount.Username.Title"] = "Username",
                ["Admin.ConfigurationSteps.EmailAccount.Username.Text"] = "Enter the user name which is used to authenticate to your email server.",
                ["Admin.ConfigurationSteps.EmailAccount.Password.Title"] = "Password",
                ["Admin.ConfigurationSteps.EmailAccount.Password.Text"] = "This is the password you use to authenticate to your mail server.",
                ["Admin.ConfigurationSteps.EmailAccount.UseSsl.Title"] = "Use SSL",
                ["Admin.ConfigurationSteps.EmailAccount.UseSsl.Text"] = "Check to use Secure Sockets Layer (SSL) to encrypt the SMTP connection.",
                ["Admin.ConfigurationSteps.EmailAccount.DefaultCredentials.Title"] = "Use default credentials",
                ["Admin.ConfigurationSteps.EmailAccount.DefaultCredentials.Text"] = "Check to use default credentials for the connection.",
                ["Admin.ConfigurationSteps.EmailAccount.TestEmail.Title"] = "Send test email",
                ["Admin.ConfigurationSteps.EmailAccount.TestEmail.Text"] = "Enter your email address and send a test email to make sure you set the email account right.",
                ["Admin.ConfigurationSteps.EmailAccountList.EmailAccounts1.Title"] = "Email accounts",
                ["Admin.ConfigurationSteps.EmailAccountList.EmailAccounts1.Text"] = "You can see all the existing email accounts on this page. Only one email account is created automatically during the installation process. You can also create a general contact email, a sales representative email, a customer support email, and more to contact your customers.",
                ["Admin.ConfigurationSteps.EmailAccountList.EmailAccounts2.Title"] = "Email accounts",
                ["Admin.ConfigurationSteps.EmailAccountList.EmailAccounts2.Text"] = "Then, these email accounts will be used to send order notifications, registration emails, and newsletters to your customers. But you may as well use only one email account for all these purposes.",
                ["Admin.ConfigurationSteps.EmailAccountList.DefaultEmailAccount.Title"] = "Default email account",
                ["Admin.ConfigurationSteps.EmailAccountList.DefaultEmailAccount.Text"] = "Don’t forget to mark one of the existing email accounts as the default one.",
                ["Admin.ConfigurationSteps.EmailAccountList.Edit.Title"] = "Edit an email account",
                ["Admin.ConfigurationSteps.EmailAccountList.Edit.Text"] = "To edit an email account click the <b>Edit</b> button.",
                ["Admin.ConfigurationSteps.PaymentMethods.PaymentMethods.Title"] = "Payment methods",
                ["Admin.ConfigurationSteps.PaymentMethods.PaymentMethods.Text"] = "You can see all the payment methods (plugins) allowed to use in your store on this page. However, you can always find much more in our marketplace.",
                ["Admin.ConfigurationSteps.PaymentMethods.CheckMoney.Title"] = "Check/money order",
                ["Admin.ConfigurationSteps.PaymentMethods.CheckMoney.Text"] = "Check/money orders are often used by government agencies or large businesses. Rather than paying directly through your site, shoppers will request that you send them a Purchase order (PO), and they will send the payment back. Most of the order processing is handled outside of the software. This method is already enabled.",
                ["Admin.ConfigurationSteps.PaymentMethods.Manual.Title"] = "Credit card (manual)",
                ["Admin.ConfigurationSteps.PaymentMethods.Manual.Text"] = "This is a special payment plugin that allows all orders to be successfully entered on the website, but it does NOT really charge a customer or make any calls to any live payment gateway. This payment method is recommended if you want to perform one of the following: <ul><li>Process all orders offline</li><li>Process them manually via another back-office system</li><li>Test the site end-to-end before going live</li></ul>",
                ["Admin.ConfigurationSteps.PaymentMethods.PayPal.Title"] = "PayPal Smart Payment Buttons",
                ["Admin.ConfigurationSteps.PaymentMethods.PayPal.Text"] = "If you want to process payments online, we’d recommend you to set up the PayPal Smart Payment Buttons payment method. PayPal Checkout with Smart Payment Buttons gives your buyers a simplified and secure checkout experience. Read more about how to set this plugin <a href=\"{0}\" target=\"_blank\">here</a>.",
                ["Admin.ConfigurationSteps.PaymentMethods.Configure.Title"] = "Configure a payment method",
                ["Admin.ConfigurationSteps.PaymentMethods.Configure.Text"] = "You can configure each payment method by clicking the appropriate <b>Configure</b> button.",
                ["Admin.ConfigurationSteps.Product.SettingsButton.Title"] = "“Settings” button",
                ["Admin.ConfigurationSteps.Product.SettingsButton.Text"] = "This “Settings” button allows you to set up the basic mode to choose which fields you want to be shown exactly on the product edit page.",
                ["Admin.ConfigurationSteps.Product.Details.Title"] = "Product details",
                ["Admin.ConfigurationSteps.Product.Details.Text"] = "Enter the relevant product details in these fields. The screenshot below shows how they will be displayed on the product page with the default nopCommerce theme: <div><img src=\"../../js/admintour/images/product-page.jpg\"/></div>",
                ["Admin.ConfigurationSteps.Product.Price.Title"] = "Product price",
                ["Admin.ConfigurationSteps.Product.Price.Text"] = "Enter the product price in a predefined currency here. Read more on how to manage currencies <a href=\"{0}\" target=\"_blank\">here</a>.",
                ["Admin.ConfigurationSteps.Product.Tax.Title"] = "Product tax category",
                ["Admin.ConfigurationSteps.Product.Tax.Text"] = "Select the product tax category or tick the <b>Tax exempt</b> if needed.",
                ["Admin.ConfigurationSteps.Product.Pictures.Title"] = "Product pictures",
                ["Admin.ConfigurationSteps.Product.Pictures.Text"] = "You can add pictures to your product after you save it for the first time. Click the <b>Save</b> button in the top right and then proceed to the pictures panel.",
                ["Admin.ConfigurationSteps.Store.Name.Title"] = "Your store name",
                ["Admin.ConfigurationSteps.Store.Name.Text"] = "Enter your store name in this field. It will be displayed, for instance, in the newsletter and notification emails sent to your customers.",
                ["Admin.ConfigurationSteps.Store.Url.Title"] = "Your store URL",
                ["Admin.ConfigurationSteps.Store.Url.Text"] = "Enter your store URL in this field. For example, it could be http://www.yourstore.com/ or https://www.yourstore.com/mystore/ if you installed your store in a subdirectory.",
                ["Admin.ConfigurationSteps.Store.Ssl.Title"] = "Enable SSL",
                ["Admin.ConfigurationSteps.Store.Ssl.Text"] = "If you already have an SSL certificate installed on the server, enable SSL to protect your customers’ data. <b>Do not enable it if you don’t have an SSL certificate installed yet!</b> SSL Certificates provide customer trust and improve site rankings. Note that some online payment methods require an SSL certificate installed for correct working. Read how to install and configure SSL certificates <a href=\"{0}\" target=\"_blank\">here</a>.",
                ["Admin.ConfigurationSteps.TaxManual.Switch.Title"] = "“Fixed rate/By country” switch",
                ["Admin.ConfigurationSteps.TaxManual.Switch.Text"] = "The “Fixed rate/By country” switch allows you to choose the type of tax rates you’d like to use in your store.",
                ["Admin.ConfigurationSteps.TaxManual.Fixed.Title"] = "“Fixed rate” option",
                ["Admin.ConfigurationSteps.TaxManual.Fixed.Text"] = "The “Fixed tax rate” option allows you to set tax rates depending on the tax category.",
                ["Admin.ConfigurationSteps.TaxManual.ByCountry.Title"] = "“By country” option",
                ["Admin.ConfigurationSteps.TaxManual.ByCountry.Text"] = "The tax rates “By country/state/zip” option allows setting different tax rates based on a country, state, or zip.",
                ["Admin.ConfigurationSteps.TaxManual.Categories.Title"] = "Tax categories",
                ["Admin.ConfigurationSteps.TaxManual.Categories.Text"] = "This table contains tax categories used by offline tax providers. A few tax categories are created automatically during the installation process.",
                ["Admin.ConfigurationSteps.TaxManual.Edit.Title"] = "Edit tax rate",
                ["Admin.ConfigurationSteps.TaxManual.Edit.Text"] = "Click the <b>Edit</b> button to edit a tax rate for the specific tax category.",
                ["Admin.ConfigurationSteps.TaxProviders.TaxProviders.Title"] = "Tax providers",
                ["Admin.ConfigurationSteps.TaxProviders.TaxProviders.Text"] = "You can see all the tax providers (plugins) allowed to use in your store on this page. However, you can always find much more in our <a href=\"{0}\" target=\"_blank\">marketplace</a>.",
                ["Admin.ConfigurationSteps.TaxProviders.Avalara.Title"] = "Avalara tax provider",
                ["Admin.ConfigurationSteps.TaxProviders.Avalara.Text"] = "You can automate the tax compliance in your store. Set up the Avalara tax provider, and you won’t need to worry about taxes anymore. Avalara is an automated tax compliance software. Read how to configure it in <a href=\"{0}\" target=\"_blank\">this article</a>.",
                ["Admin.ConfigurationSteps.TaxProviders.Manual.Title"] = "Manual tax provider",
                ["Admin.ConfigurationSteps.TaxProviders.Manual.Text"] = "Manual tax provider allows you to set up fixed tax rates depending on the country/state/zip.",
                ["Admin.ConfigurationSteps.TaxProviders.PrimaryProvider.Title"] = "Mark as a primary provider",
                ["Admin.ConfigurationSteps.TaxProviders.PrimaryProvider.Text"] = "You can mark the desired tax provider as a primary one using the <b>Mark as primary provider</b> button.",
                ["Admin.ConfigurationSteps.TaxProviders.Configure.Title"] = "Configure Manual",
                ["Admin.ConfigurationSteps.TaxProviders.Configure.Text"] = "Now we’ll configure the Manual tax provider. Click the <b>Edit</b> button to proceed to the plugin configuration page.",
                ["Admin.ConfigurationSteps.Topic.TitleContent.Title"] = "Title and content",
                ["Admin.ConfigurationSteps.Topic.TitleContent.Text"] = "Enter a topic (page) title and its content in this field. This is what customers will see in the public store.",
                ["Admin.ConfigurationSteps.Topic.Preview.Title"] = "Preview the page",
                ["Admin.ConfigurationSteps.Topic.Preview.Text"] = "To find out how your customers will see the page, click the <b>Preview</b> button.",
                ["Admin.ConfigurationSteps.TopicList.Topics1.Title"] = "Topics (pages)",
                ["Admin.ConfigurationSteps.TopicList.Topics1.Text"] = "Topics (pages) are free-form content blocks that can be displayed on your site, either embedded within other pages or on their own pages. They are often used for FAQ pages, policy pages, special instructions, and more.",
                ["Admin.ConfigurationSteps.TopicList.Topics2.Title"] = "Topics (pages)",
                ["Admin.ConfigurationSteps.TopicList.Topics2.Text"] = "In this table, you can see a list of the topics created by default.",
                ["Admin.ConfigurationSteps.TopicList.Location.Title"] = "Page link location",
                ["Admin.ConfigurationSteps.TopicList.Location.Text"] = "As you can see, this topic is included in the first column of the footer.",
                ["Admin.ConfigurationSteps.TopicList.Edit.Title"] = "Edit the page",
                ["Admin.ConfigurationSteps.TopicList.Edit.Text"] = "To edit this page, click the <b>Edit</b> button. You can also create a new topic by clicking the <b>Add new</b> button at the top of the page.",
                ["Admin.ConfigurationSteps.PaymentMethods.Activate.Text"] = "To activate a payment method click the <b>Edit</b> button, then tick the <b>Is active</b> checkbox and save the changes.",
                ["Admin.ConfigurationSteps.PaymentMethods.Activate.Title"] = "Activate a payment method",

                //#5216
                ["Admin.Reports.SalesSummary"] = "Sales summary",
                ["Admin.Reports.SalesSummary.BillingCountry"] = "Billing country",
                ["Admin.Reports.SalesSummary.BillingCountry.Hint"] = "Filter by order billing country.",
                ["Admin.Reports.SalesSummary.EndDate"] = "End date",
                ["Admin.Reports.SalesSummary.EndDate.Hint"] = "The end date for the search.",
                ["Admin.Reports.SalesSummary.OrderStatus"] = "Order status",
                ["Admin.Reports.SalesSummary.OrderStatus.Hint"] = "Search by a specific order status e.g. Complete.",
                ["Admin.Reports.SalesSummary.PaymentStatus"] = "Payment status",
                ["Admin.Reports.SalesSummary.PaymentStatus.Hint"] = "Search by a specific payment status e.g. Paid.",
                ["Admin.Reports.SalesSummary.RunReport"] = "Run report",
                ["Admin.Reports.SalesSummary.StartDate"] = "Start date",
                ["Admin.Reports.SalesSummary.StartDate.Hint"] = "The start date for the search.",
                ["Admin.Reports.SalesSummary.Store"] = "Store",
                ["Admin.Reports.SalesSummary.Store.Hint"] = "Filter report by orders placed in a specific store.",
                ["Admin.Reports.SalesSummary.Product"] = "Product",
                ["Admin.Reports.SalesSummary.Product.Hint"] = "Search by a specific product.",
                ["Admin.Reports.SalesSummary.GroupBy"] = "Group by",
                ["Admin.Reports.SalesSummary.GroupBy.Hint"] = "Grouping by time periods.",
                ["Enums.Nop.Services.Orders.GroupByOptions.Day"] = "Day",
                ["Enums.Nop.Services.Orders.GroupByOptions.Week"] = "Week",
                ["Enums.Nop.Services.Orders.GroupByOptions.Month"] = "Month",
                ["Admin.Reports.SalesSummary.Fields.Summary"] = "Summary",
                ["Admin.Reports.SalesSummary.Fields.NumberOfOrders"] = "Number of orders",
                ["Admin.Reports.SalesSummary.Fields.Profit"] = "Profit",
                ["Admin.Reports.SalesSummary.Fields.Tax"] = "Tax",
                ["Admin.Reports.SalesSummary.Fields.OrderTotal"] = "OrderTotal",

                //#4196
                ["Admin.Configuration.AppSettings.Common.PluginStaticFileExtensionsBlacklist"] = "Plugin static file extensions blacklist",
                ["Admin.Configuration.AppSettings.Common.PluginStaticFileExtensionsBlacklist.Hint"] = "Specify the blacklist of static file extension for plugin directories.",
                ["Admin.Configuration.AppSettings.Common.ScheduleTaskRunTimeout"] = "Schedule task run timeout",
                ["Admin.Configuration.AppSettings.Common.ScheduleTaskRunTimeout.Hint"] = "The length of time, in milliseconds, a running schedule task timeouts. Set null to use a default value.",
                ["Admin.Configuration.AppSettings.Common.StaticFilesCacheControl"] = "Static files cache control",
                ["Admin.Configuration.AppSettings.Common.StaticFilesCacheControl.Hint"] = "Specify a value of 'Cache - Control' header value for static content (in seconds).",
                ["Admin.Configuration.AppSettings.Common.SupportPreviousNopcommerceVersions"] = "Support previous nopCommerce versions",
                ["Admin.Configuration.AppSettings.Common.SupportPreviousNopcommerceVersions.Hint"] = "Specify a value indicating whether we should support previous nopCommerce versions (it can slightly improve performance). In this case, old URLs (from previous nopCommerce versions) will redirect to new ones. Enable it only if you upgraded from one of the previous nopCommerce versions.",
                ["Admin.Configuration.AppSettings.Description"] = "Configuration in ASP.NET Core is performed using a configuration provider from the external appsettings.json configuration file. These settings are used when the application is launched, so after editing them, the application will be restarted. You can find a detailed description of all configuration parameters in <a href=\"{0}\" target=\"_blank\">our documentation.</a>",

                //#3015
                ["Admin.Configuration.Settings.GeneralCommon.HomepageTitle"] = "Home page title",
                ["Admin.Configuration.Settings.GeneralCommon.HomepageTitle.Hint"] = "The title for the home page in your store.",
                ["Admin.Configuration.Settings.GeneralCommon.HomepageDescription"] = "Home page meta description",
                ["Admin.Configuration.Settings.GeneralCommon.HomepageDescription.Hint"] = "The description for the home page in your store.",

                //#5210
                ["Admin.Documentation.Reference.Products"] = "Learn more about <a target=\"_blank\" href=\"{0}\">products</a>",
                ["Admin.Documentation.Reference.ProductAttributes"] = "Learn more about <a target=\"_blank\" href=\"{0}\">product attributes</a>",
                ["Admin.Documentation.Reference.SpecificationAttributes"] = "Learn more about <a target=\"_blank\" href=\"{0}\">specification attributes</a>",
                ["Admin.Documentation.Reference.CheckoutAttributes"] = "Learn more about <a target=\"_blank\" href=\"{0}\">checkout attributes</a>",
                ["Admin.Documentation.Reference.Orders"] = "Learn more about <a target=\"_blank\" href=\"{0}\">orders</a>",
                ["Admin.Documentation.Reference.RecurringPayments"] = "Learn more about <a target=\"_blank\" href=\"{0}\">recurring products</a>",
                ["Admin.Documentation.Reference.ShoppingCartsAndWishlists"] = "Learn more about <a target=\"_blank\" href=\"{0}\">shopping carts and wishlists</a>",
                ["Admin.Documentation.Reference.Customers"] = "Learn more about <a target=\"_blank\" href=\"{0}\">customers</a>",
                ["Admin.Documentation.Reference.CustomerRoles"] = "Learn more about <a target=\"_blank\" href=\"{0}\">customer roles</a>",
                ["Admin.Documentation.Reference.OnlineCustomers"] = "Learn more about <a target=\"_blank\" href=\"{0}\">online customers</a>",
                ["Admin.Documentation.Reference.ActivityLog"] = "Learn more about <a target=\"_blank\" href=\"{0}\">activity log</a>",
                ["Admin.Documentation.Reference.Gdpr"] = "Learn more about <a target=\"_blank\" href=\"{0}\">GDPR in nopCommerce</a>",
                ["Admin.Documentation.Reference.Discounts"] = "Learn more about <a target=\"_blank\" href=\"{0}\">discounts</a>",
                ["Admin.Documentation.Reference.Affiliates"] = "Learn more about <a target=\"_blank\" href=\"{0}\">affiliates</a>",
                ["Admin.Documentation.Reference.EmailCampaigns"] = "Learn more about <a target=\"_blank\" href=\"{0}\">email campaigns</a>",
                ["Admin.Documentation.Reference.TopicsPages"] = "Learn more about <a target=\"_blank\" href=\"{0}\">topics (pages)</a>",
                ["Admin.Documentation.Reference.MessageTemplates"] = "Learn more about <a target=\"_blank\" href=\"{0}\">message templates</a>",
                ["Admin.Documentation.Reference.News"] = "Learn more about <a target=\"_blank\" href=\"{0}\">news</a>",
                ["Admin.Documentation.Reference.Blog"] = "Learn more about <a target=\"_blank\" href=\"{0}\">blog</a>",
                ["Admin.Documentation.Reference.Polls"] = "Learn more about <a target=\"_blank\" href=\"{0}\">polls</a>",
                ["Admin.Documentation.Reference.Forums"] = "Learn more about <a target=\"_blank\" href=\"{0}\">forums</a>",
                ["Admin.Documentation.Reference.EmailAccounts"] = "Learn more about <a target=\"_blank\" href=\"{0}\">email accounts</a>",
                ["Admin.Documentation.Reference.MultiStore"] = "Learn more about <a target=\"_blank\" href=\"{0}\">multi-store</a>",
                ["Admin.Documentation.Reference.CountriesStates"] = "Learn more about <a target=\"_blank\" href=\"{0}\">countries and states</a>",
                ["Admin.Documentation.Reference.Localization"] = "Learn more about <a target=\"_blank\" href=\"{0}\">localization</a>",
                ["Admin.Documentation.Reference.Currencies"] = "Learn more about <a target=\"_blank\" href=\"{0}\">currencies</a>",
                ["Admin.Documentation.Reference.PaymentMethods"] = "Learn more about <a target=\"_blank\" href=\"{0}\">payment methods</a>.",
                ["Admin.Documentation.Reference.PaymentMethodRestrictions"] = "Learn more about <a target=\"_blank\" href=\"{0}\">payment method restrictions</a>",
                ["Admin.Documentation.Reference.TaxProviders"] = "Learn more about <a target=\"_blank\" href=\"{0}\">tax providers</a>.",
                ["Admin.Documentation.Reference.DatesAndRanges"] = "Learn more about <a target=\"_blank\" href=\"{0}\">dates and ranges</a>",
                ["Admin.Documentation.Reference.Acl"] = "Learn more about <a target=\"_blank\" href=\"{0}\">access control list</a>",
                ["Admin.Documentation.Reference.ExternalAuthentication"] = "Learn more about <a target=\"_blank\" href=\"{0}\">external authentication methods</a>",
                ["Admin.Documentation.Reference.Plugins"] = "Learn more about <a target=\"_blank\" href=\"{0}\">plugins in nopCommerce</a>",
                ["Admin.Documentation.Reference.Log"] = "Learn more about <a target=\"_blank\" href=\"{0}\">log</a>",
                ["Admin.Documentation.Reference.Maintenance"] = "Learn more about <a target=\"_blank\" href=\"{0}\">maintenance</a>",
                ["Admin.Documentation.Reference.MessageQueue"] = "Learn more about <a target=\"_blank\" href=\"{0}\">message queue</a>",
                ["Admin.Documentation.Reference.ScheduleTasks"] = "Learn more about <a target=\"_blank\" href=\"{0}\">scheduled tasks</a>",
                ["Admin.Documentation.Reference.SeoOptimization"] = "Learn more about <a target=\"_blank\" href=\"{0}\">search engine optimization</a>",
                ["Admin.Documentation.Reference.Templates"] = "Learn more about <a target=\"_blank\" href=\"{0}\">templates</a>",
                ["Admin.Documentation.Reference.Reports"] = "Learn more about <a target=\"_blank\" href=\"{0}\">reports</a>",
                ["Admin.Documentation.Reference.TaxManagement"] = "Learn more about <a target=\"_blank\" href=\"{0}\">tax management</a>",

                //#3950
                ["Admin.Catalog.Products.ProductAttributes.Attributes.AlreadyExistsInCombination"] = "This attribute already exists in combination: '{0}'.",

                //#4564
                ["Admin.Common.Validation.NotEmpty"] = "Please provide a {0}",

                //#3296
                ["Plugins.Payments.PayPalStandard.Instructions"] = @"
                    <p>
	                    <b>If you're using this gateway ensure that your primary store currency is supported by PayPal.</b>
	                    <br />
	                    <br />To use PDT, you must activate PDT and Auto Return in your PayPal account profile. You must also acquire a PDT identity token, which is used in all PDT communication you send to PayPal. Follow these steps to configure your account for PDT:<br />
	                    <br />1. Log in to your PayPal account (click <a href=""https://www.paypal.com/us/webapps/mpp/referral/paypal-business-account2?partner_id=9JJPJNNPQ7PZ8"" target=""_blank"">here</a> to create your account).
	                    <br />2. Click on the Profile button.
	                    <br />3. Click on the <b>Account Settings</b> link.
	                    <br />4. Select the <b>Website payments</b> item on left panel.
	                    <br />5. Find <b>Website Preferences</b> and click on the <b>Update</b> link.
	                    <br />6. Under <b>Auto Return</b> for <b>Website payments preferences</b>, select the <b>On</b> radio button.
	                    <br />7. For the <b>Return URL</b>, enter and save the URL on your site that will receive the transaction ID posted by PayPal after a customer payment (<em>{0}</em>).
                        <br />8. Under <b>Payment Data Transfer</b>, select the <b>On</b> radio button and get your <b>Identity token</b>.
	                    <br />9. Enter <b>Identity token</b> in the field below on the plugin configuration page.
                        <br />10. Click <b>Save</b> button on this page.
	                    <br />
                    </p>",

                ["Admin.Configuration.LanguagePackProgressMessage"] = "The localization pack downloaded when installing the store has been translated by {0}%. If you would like to contribute to localization, please visit our <a href=\"{1}\" target=\"_blank\">translations page.</a>",

                //#5319
                ["Plugins.Tax.FixedOrByCountryStateZip.TaxCategoriesCanNotLoaded"] = "No tax categories can be loaded. You may manage tax categories by <a href='{0}'>this link</a>",

                //#5245
                ["Plugins.Tax.FixedOrByCountryStateZip.Tax.Categories.Manage"] = "Manage tax categories",

                //#4939
                ["Admin.Configuration.Settings.GeneralCommon.Captcha.Instructions"] = "CAPTCHA is a program that can tell whether it is a human or a computer is trying to access your web site. nopCommerce uses <a href=\"http://www.google.com/recaptcha\" target=\"_blank\">reCAPTCHA</a> by Google. reCAPTCHA is a free service that protects your website from spam and abuse. reCAPTCHA uses an advanced risk analysis engine and adaptive challenges to keep automated software from engaging in abusive activities on your site. It does this while letting your valid users pass through with ease.",
                ["Admin.Configuration.AppSettings.EnvironmentVariablesWarning"] = "Warning! The current setting value is overridden in environment variables",

                //#16 #2909
                ["Products.ProductAttributes.DropdownList.DefaultItem"] = "Please select",
                ["Products.ProductAttributes.NotAvailable"] = "Not available",

                ["Checkout.PickupPoints.NullName"] = "Pickup",

                //#5400
                ["Admin.ContentManagement.Forums.Forum.Fields.Name.Required"] = "Forum name is required.",

                //#5482
                ["Plugins.Tax.Avalara.Fields.GetTaxRateByAddressOnly"] = "Tax rates by address only",
                ["Plugins.Tax.Avalara.Fields.GetTaxRateByAddressOnly.Hint"] = "Determine whether to get tax rates by the address only. This may lead to not entirely accurate results (for example, when a customer is exempt to tax, or the product belongs to a tax category that has a specific rate), but it will significantly reduce the number of GetTax API calls. This applies only to tax rates in the catalog, on the checkout full information is always used in requests.",

            }, languageId).Wait();

            // rename locales
            var localesToRename = new[]
            {
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.Added", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Added" },
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.AddNew", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.AddNew" },
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.BackToList", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.BackToList" },
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.Deleted", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Deleted" },
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.EditAttributeDetails", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.EditAttributeDetails" },
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.Fields.DisplayOrder", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Fields.DisplayOrder" },
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.Fields.DisplayOrder.Hint", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Fields.DisplayOrder.Hint" },
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.Fields.Name", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Fields.Name" },
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.Fields.Name.Hint", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Fields.Name.Hint" },
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.Fields.Name.Required", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Fields.Name.Required" },
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.Info", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Info" },
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.Options", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Options" },
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.Options.AddNew", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Options.AddNew" },
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.Options.EditOptionDetails", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Options.EditOptionDetails" },
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.Options.Fields.ColorSquaresRgb", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Options.Fields.ColorSquaresRgb" },
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.Options.Fields.ColorSquaresRgb.Hint", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Options.Fields.ColorSquaresRgb.Hint" },
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.Options.Fields.DisplayOrder", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Options.Fields.DisplayOrder" },
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.Options.Fields.DisplayOrder.Hint", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Options.Fields.DisplayOrder.Hint" },
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.Options.Fields.EnableColorSquaresRgb", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Options.Fields.EnableColorSquaresRgb" },
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.Options.Fields.EnableColorSquaresRgb.Hint", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Options.Fields.EnableColorSquaresRgb.Hint" },
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.Options.Fields.Name", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Options.Fields.Name" },
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.Options.Fields.Name.Hint", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Options.Fields.Name.Hint" },
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.Options.Fields.Name.Required", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Options.Fields.Name.Required" },
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.Options.Fields.NumberOfAssociatedProducts", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Options.Fields.NumberOfAssociatedProducts" },
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.Options.SaveBeforeEdit", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Options.SaveBeforeEdit" },
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.Updated", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Updated" },
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.UsedByProducts", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.UsedByProducts" },
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.UsedByProducts.Product", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.UsedByProducts.Product" },
                new { Name = "Admin.Catalog.Attributes.SpecificationAttributes.UsedByProducts.Published", NewName = "Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.UsedByProducts.Published" },
                
                //#475
                new { Name = "Admin.Configuration.ExternalAuthenticationMethods.Fields.DisplayOrder", NewName = "Admin.Configuration.Authentication.ExternalMethods.Fields.DisplayOrder"},
                new { Name = "Admin.Configuration.ExternalAuthenticationMethods.Fields.FriendlyName", NewName = "Admin.Configuration.Authentication.ExternalMethods.Fields.FriendlyName"},
                new { Name = "Admin.Configuration.ExternalAuthenticationMethods.Fields.IsActive", NewName = "Admin.Configuration.Authentication.ExternalMethods.Fields.IsActive"},
                new { Name = "Admin.Configuration.ExternalAuthenticationMethods.Fields.SystemName", NewName = "Admin.Configuration.Authentication.ExternalMethods.Fields.SystemName"},
                new { Name = "Admin.Configuration.ExternalAuthenticationMethods.BackToList", NewName = "Admin.Configuration.Authentication.ExternalMethods.BackToList"},
                new { Name = "Admin.Configuration.ExternalAuthenticationMethods.Configure", NewName = "Admin.Configuration.Authentication.ExternalMethods.Configure"},
                new { Name = "Admin.Configuration.ExternalAuthenticationMethods", NewName = "Admin.Configuration.Authentication.ExternalMethods"},
                new { Name = "Permission.ManageExternalAuthenticationMethods", NewName = "Permission.Authentication.ManageExternalMethods"},
                
                //#4564
                new { Name = "Nop.Web.Framework.Validators.MaxDecimal", NewName = "Admin.Common.Validation.Decimal.Max"},

                //#5321
                new { Name = "Common.Wait...", NewName = "Common.Wait"},

                //#5429
                new { Name = "Search.NoResultsText", NewName = "Catalog.Products.NoResult"},

            };

            foreach (var lang in languages)
            {
                foreach (var locale in localesToRename)
                {
                    var lsr = localizationService.GetLocaleStringResourceByNameAsync(locale.Name, lang.Id, false).Result;
                    if (lsr != null)
                    {
                        lsr.ResourceName = locale.NewName;
                        localizationService.UpdateLocaleStringResourceAsync(lsr).Wait();
                    }
                }
            }
        }

        /// <summary>Collects the DOWN migration expressions</summary>
        public override void Down()
        {
            //add the downgrade logic if necessary 
        }
    }
}
