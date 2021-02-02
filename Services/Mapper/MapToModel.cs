using Domain.Models;
using Infrastructure.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper
{
    public class MapToModel
    {
        /// <summary>
        /// Map accessory model to dto.
        /// </summary>
        /// <param name="accessory"></param>
        /// <returns></returns>
        public static Accessory AccessoryDtoMapToModel(AccessoryDto accessory)
        {
            return new Accessory()
            {
                Brand = accessory.Brand,
                Color = accessory.Color,
                ImmediateSending = accessory.ImmediateSending,
                Model = accessory.Model,
                Name = accessory.Name,
                Price = accessory.Price,
                Remaining = accessory.Remaining,
                SalesNumber = accessory.SalesNumber,
                Type = accessory.Type,
                Weight = accessory.Weight,
                AttachmentImageId = accessory.AttachmentImageId,
                Description = accessory.Description
            };
        }


        public static AttachmentFile AttachmentFileDtoMapToModel(AttachmentFileDto attachmentFile)
        {
            return new AttachmentFile()
            {
                Binary = attachmentFile.Binary,
                Description = attachmentFile.Description,
                Extension = attachmentFile.Extension,
                ImageHeight = attachmentFile.ImageHeight,
                ImageWidth = attachmentFile.ImageWidth,
                IsBinaryStorage = attachmentFile.IsBinaryStorage,
                IsPhysicalStorage = attachmentFile.IsPhysicalStorage,
                LastModified = attachmentFile.LastModified,
                MimeType = attachmentFile.MimeType,
                PhysicalPath = attachmentFile.PhysicalPath,
                Size = attachmentFile.Size,
                Title = attachmentFile.Title,
                PosterImageGuid = attachmentFile.PosterImageGuid,
                Name = attachmentFile.Name,
            };
        }
        /// <summary>
        /// Map assembled cast to dto.
        /// </summary>
        /// <param name="assembledCase"></param>
        /// <returns></returns>
        public static AssembledCase AssembledCaseDtoMapToModel(AssembledCaseDto assembledCase)
        {
            return new AssembledCase()
            {
                Weight = assembledCase.Weight,
                Type = assembledCase.Type,
                SalesNumber = assembledCase.SalesNumber,
                Brand = assembledCase.Brand,
                Color = assembledCase.Color,
                CPU_Company = assembledCase.CPU_Company,
                ImmediateSending = assembledCase.ImmediateSending,
                IntrnalStorageType = assembledCase.IntrnalStorageType,
                Model = assembledCase.Model,
                Name = assembledCase.Name,
                Price = assembledCase.Price,
                RAM = assembledCase.RAM,
                Remaining = assembledCase.Remaining,
                Storage = assembledCase.Storage,
                AttachmentImageId = assembledCase.AttachmentImageId,
                PromotionId = assembledCase.SelectedPromotionId == null ? Guid.Empty : assembledCase.SelectedPromotionId,
                Description = assembledCase.Description
            };
        }
        /// <summary>
        /// Map Comment to comment dto.
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public static Comment CommentDtoMapToModel(CommentDto comment)
        {
            return new Comment()
            {
                Name = comment.Name,
                CommodityId = comment.CommodityId,
                Advantages = comment.Advantages,
                Content = comment.Content,
                ID = comment.ID != Guid.Empty ? comment.ID : Guid.NewGuid(),
                DisAdvantages = comment.DisAdvantages,
                HasContent = comment.HasContent,
                SuggestToFriends = comment.SuggestToFriends,
                Title = comment.Title
            };
        }
        /// <summary>
        /// Map Commodity to dto.
        /// </summary>
        /// <param name="commodity"></param>
        /// <returns></returns>
        public static Commodity CommodityDtoMapToModel(CommodityDto commodity)
        {
            return new Commodity()
            {
                Brand = commodity.Brand,
                Color = commodity.Color,
                ImmediateSending = commodity.ImmediateSending,
                Name = commodity.Name,
                Price = commodity.Price,
                Remaining = commodity.Remaining,
                SalesNumber = commodity.SalesNumber,
                Type = commodity.Type,
                Weight = commodity.Weight,
                PromotionId = commodity.SelectedPromotionId,
                Description = commodity.Description
            };
        }
        /// <summary>
        /// Map External hard to dto.
        /// </summary>
        /// <param name="externalHard"></param>
        /// <returns></returns>
        public static ExternalHard ExternalHardDtoMapToModel(ExternalHardDto externalHard)
        {
            return new ExternalHard()
            {
                Weight = externalHard.Weight,
                Brand = externalHard.Brand,
                Color = externalHard.Color,
                ConnectionType = externalHard.ConnectionType,
                ImmediateSending = externalHard.ImmediateSending,
                ImpactResistance = externalHard.ImpactResistance,
                Name = externalHard.Name,
                Price = externalHard.Price,
                Remaining = externalHard.Remaining,
                SalesNumber = externalHard.SalesNumber,
                Model = externalHard.Model,
                StirageType = externalHard.StirageType,
                Type = externalHard.Type,
                WaterResistance = externalHard.WaterResistance,
                AttachmentImageId = externalHard.AttachmentImageId,
                PromotionId = externalHard.SelectedPromotionId == null ? Guid.Empty : externalHard.SelectedPromotionId,
                Description = externalHard.Description
            };
        }
        /// <summary>
        /// Map Keyboard hard to dto.
        /// </summary>
        /// <param name="keyboard"></param>
        /// <returns></returns>
        public static Keyboard KeyboardDtoMapToModel(KeyboardDto keyboard)
        {
            return new Keyboard()
            {
                Type = keyboard.Type,
                SalesNumber = keyboard.SalesNumber,
                Remaining = keyboard.Remaining,
                Backlight = keyboard.Backlight,
                Brand = keyboard.Brand,
                CarvedPersian = keyboard.CarvedPersian,
                Color = keyboard.Color,
                ConnectionType = keyboard.ConnectionType,
                ConnectorType = keyboard.ConnectorType,
                HaveMouse = keyboard.HaveMouse,
                ImmediateSending = keyboard.ImmediateSending,
                Model = keyboard.Model,
                LiquidResistance = keyboard.LiquidResistance,
                MicrophoneInput = keyboard.MicrophoneInput,
                Name = keyboard.Name,
                Price = keyboard.Price,
                USB_Input = keyboard.USB_Input,
                Weight = keyboard.Weight,
                AttachmentImageId = keyboard.AttachmentImageId,
                PromotionId = keyboard.SelectedPromotionId == null ? Guid.Empty : keyboard.SelectedPromotionId,
                Description = keyboard.Description
            };
        }
        /// <summary>
        /// Map laptop to dto.
        /// </summary>
        /// <param name="laptop"></param>
        /// <returns></returns>
        public static Laptop LaptopDtoMapToModel(LaptopDto laptop)
        {
            return new Laptop()
            {
                Brand = laptop.Brand,
                Color = laptop.Color,
                CPU = laptop.CPU,
                GPU_Company = laptop.GPU_Company,
                GPU_Size = laptop.GPU_Size,
                ImmediateSending = laptop.ImmediateSending,
                InternalStorage = laptop.InternalStorage,
                IsTouchable = laptop.IsTouchable,
                LaptopRam = laptop.LaptopRam,
                MatteImage = laptop.MatteImage,
                Name = laptop.Name,
                OS = laptop.OS,
                Price = laptop.Price,
                RAM_Size = laptop.RAM_Size,
                RAM_Type = laptop.RAM_Type,
                Remaining = laptop.Remaining,
                SalesNumber = laptop.SalesNumber,
                ScreenResolution = laptop.ScreenResolution,
                ScreenSize = laptop.ScreenSize,
                Description = laptop.Description,
                Type = laptop.Type,
                Weight = laptop.Weight,
                AttachmentImageId = laptop.AttachmentImageId,
                PromotionId = laptop.SelectedPromotionId == null ? Guid.Empty : laptop.SelectedPromotionId
            };
        }
        /// <summary>
        /// Map Monile to Dto.
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static Mobile MobileDtoMapToModel(MobileDto mobile)
        {
            return new Mobile()
            {
                Weight = mobile.Weight,
                Type = mobile.Type,
                Brand = mobile.Brand,
                CameraResolution = mobile.CameraResolution,
                Color = mobile.Color,
                ImmediateSending = mobile.ImmediateSending,
                InternalStorage = mobile.InternalStorage,
                MobileRam = mobile.MobileRam,
                Description = mobile.Description,
                Model = mobile.Model,
                Name = mobile.Name,
                Network = mobile.Network,
                OS = mobile.OS,
                Price = mobile.Price,
                Remaining = mobile.Remaining,
                SalesNumber = mobile.SalesNumber,
                AttachmentImageId = mobile.AttachmentImageId,
                PromotionId = mobile.SelectedPromotionId == null ? Guid.Empty : mobile.SelectedPromotionId
            };
        }
        /// <summary>
        /// Map Mobile Holder to Dto.
        /// </summary>
        /// <param name="mobileHolder"></param>
        /// <returns></returns>
        public static MobileHolder MobileHolderDtoMapToModel(MobileHolderDto mobileHolder)
        {
            return new MobileHolder()
            {
                SalesNumber = mobileHolder.SalesNumber,
                Remaining = mobileHolder.Remaining,
                Price = mobileHolder.Price,
                Brand = mobileHolder.Brand,
                Color = mobileHolder.Color,
                ImmediateSending = mobileHolder.ImmediateSending,
                Model = mobileHolder.Model,
                Name = mobileHolder.Name,
                Description = mobileHolder.Description,
                Rechargeable = mobileHolder.Rechargeable,
                Rotate360 = mobileHolder.Rotate360,
                Type = mobileHolder.Type,
                Weight = mobileHolder.Weight,
                WirelessCharging = mobileHolder.WirelessCharging,
                AttachmentImageId = mobileHolder.AttachmentImageId,
                PromotionId = mobileHolder.SelectedPromotionId == null ? Guid.Empty : mobileHolder.SelectedPromotionId,

            };
        }
        /// <summary>
        /// Map Mobile Cover to Dto.
        /// </summary>
        /// <param name="mobileCover"></param>
        /// <returns></returns>
        public static MobileCover MobileCoverDtoMapToModel(MobileCoverDto mobileCover)
        {
            return new MobileCover()
            {
                Weight = mobileCover.Weight,
                Brand = mobileCover.Brand,
                Color = mobileCover.Color,
                ForMobile = mobileCover.ForMobile,
                ImmediateSending = mobileCover.ImmediateSending,
                Material = mobileCover.Material,
                Model = mobileCover.Model,
                Name = mobileCover.Name,
                Price = mobileCover.Price,
                Remaining = mobileCover.Remaining,
                Description = mobileCover.Description,
                SalesNumber = mobileCover.SalesNumber,
                Size = mobileCover.Size,
                SpecialFeature = mobileCover.SpecialFeature,
                Type = mobileCover.Type,
                AttachmentImageId = mobileCover.AttachmentImageId,
                PromotionId = mobileCover.SelectedPromotionId == null ? Guid.Empty : mobileCover.SelectedPromotionId
            };
        }
        /// <summary>
        /// Map Monitor to Dto.
        /// </summary>
        /// <param name="monitor"></param>
        /// <returns></returns>
        public static Monitor MonitorDtoMapToModel(MonitorDto monitor)
        {
            return new Monitor()
            {
                Backlight = monitor.Backlight,
                Brand = monitor.Brand,
                Color = monitor.Color,
                DVI_Port = monitor.DVI_Port,
                HDMI_Port = monitor.HDMI_Port,
                ImmediateSending = monitor.ImmediateSending,
                Description = monitor.Description,
                Name = monitor.Name,
                PanelType = monitor.PanelType,
                Price = monitor.Price,
                Remaining = monitor.Remaining,
                Resolution = monitor.Resolution,
                ResponseTime = monitor.ResponseTime,
                SalesNumber = monitor.SalesNumber,
                Model = monitor.Model,
                Speaker = monitor.Speaker,
                Type = monitor.Type,
                USB_Port = monitor.USB_Port,
                Weight = monitor.Weight,
                AttachmentImageId = monitor.AttachmentImageId,
                PromotionId = monitor.SelectedPromotionId == null ? Guid.Empty : monitor.SelectedPromotionId
            };
        }
        /// <summary>
        /// Map person to Dto.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public static Person PersonModelMapToModel(PersonDto person)
        {
            return new Person()
            {
                Email = person.Email,
                FirstName = person.FirstName,
                IsLogin = person.IsLogin,
                IsRegister = person.IsRegister,
                LastName = person.LastName,
                MobileNumber = person.MobileNumber,

            };
        }
        /// <summary>
        /// Map Power bank to Dto.
        /// </summary>
        /// <param name="powerBank"></param>
        /// <returns></returns>
        public static PowerBank PowerBankDtoMapToModel(PowerBankDto powerBank)
        {
            var x = new PowerBank()
            {
                BodyMaterial = powerBank.BodyMaterial,
                Brand = powerBank.Brand,
                Capacity = powerBank.Capacity,
                Color = powerBank.Color,
                Flow = powerBank.Flow,
                ImmediateSending = powerBank.ImmediateSending,
                Model = powerBank.Model,
                Name = powerBank.Name,
                Description = powerBank.Description,
                OutputNumbers = powerBank.OutputNumbers,
                Price = powerBank.Price,
                Remaining = powerBank.Remaining,
                SalesNumber = powerBank.SalesNumber,
                SpecialFeatures = powerBank.SpecialFeatures,
                Type = powerBank.Type,
                Weight = powerBank.Weight,
                WeightClass = powerBank.WeightClass,
                AttachmentImageId = powerBank.AttachmentImageId,
                PromotionId = powerBank.SelectedPromotionId == null ? Guid.Empty : powerBank.SelectedPromotionId
            };
            return x;
        }
        /// <summary>
        /// Map Promotion to Dto.
        /// </summary>
        /// <param name="promotion"></param>
        /// <returns></returns>
        public static Promotion PromotionDtoMapToModel(PromotionDto promotion)
        {
            return new Promotion()
            {
                Type = promotion.Type,
                Percent = promotion.Percent,
                Status = promotion.Status,
                ID = promotion.ID != Guid.Empty ? promotion.ID : Guid.NewGuid()
        };
    }
}
}
