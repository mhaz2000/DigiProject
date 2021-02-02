using Domain.Models;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Configuration
{
    public class Settings
    {
        private static bool? _applicationPhysicalStorage = true;
        private static string _blobStoragePath = null;
        private static string _physicalStoragePath = null;
        private static bool? _applicationBinaryStorage = null;

        public static bool Application_BinaryStorage
        {
            get
            {
                if (_applicationBinaryStorage == null)
                {
                    _applicationBinaryStorage = bool.Parse(GetValue("Application_BinaryStorage", "false"));
                }

                return _applicationBinaryStorage ?? false;
            }
            set
            {
                SaveValue("Application_BinaryStorage", value.ToString());
                _applicationBinaryStorage = value;
            }
        }
        public static string PhysicalStoragePath
        {
            get
            {
                if (_physicalStoragePath == null)
                {
                    _physicalStoragePath = GetValue("PhysicalStoragePath", HttpContext.Current.Server.MapPath("/PhysicalStorage"));
                }

                return _physicalStoragePath;
            }
            set
            {
                var propertyValue = value == null ? "" : value.ToString();
                SaveValue("PhysicalStoragePath", propertyValue);
                _physicalStoragePath = propertyValue;
            }
        }
        public static bool Application_PhysicalStorage
        {
            get
            {
                if (_applicationPhysicalStorage == null)
                {
                    _applicationPhysicalStorage = bool.Parse(GetValue("Application_PhysicalStorage", "false"));
                }

                return _applicationPhysicalStorage ?? false;
            }
            set
            {
                SaveValue("Application_PhysicalStorage", value.ToString());
                _applicationPhysicalStorage = value;
            }
        }

        public static string BlobStoragePath
        {
            get
            {
                if (_blobStoragePath == null)
                {
                    _blobStoragePath = GetValue("BlobStoragePath", Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "/PhysicalStorage"));
                }

                return _blobStoragePath;
            }
            set
            {
                var propertyValue = value == null ? "" : value.ToString();
                SaveValue("BlobStoragePath", propertyValue);
                _blobStoragePath = propertyValue;
            }
        }

        private static string GetValue(string key, string defaultValue = null)
        {
            using (DataContext dataContext = new DataContext())
            {
                var setting = dataContext.SettingRepository.Get(q => q.Key == key);
                if (setting != null)
                    return setting.Value;

                return defaultValue;
            }
        }

        private static void SaveValue(string key, string value)
        {
            using (DataContext dataContext = new DataContext())
            {
                var setting = dataContext.SettingRepository.Get(q => q.Key == key);

                if (setting != null)
                    setting.Value = value;
                else
                {
                    setting = new Setting()
                    {
                        Id = Guid.NewGuid(),
                        Key = key,
                        Value = value
                    };
                    dataContext.SettingRepository.Insert(setting);
                }
                dataContext.Save();
            }

        }
    }
}
