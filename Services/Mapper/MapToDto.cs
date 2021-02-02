using Domain.Models;
using Infrastructure.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper
{
    public class MapToDto
    {
        /// <summary>
        /// Map accessory model to dto.
        /// </summary>
        /// <param name="accessory"></param>
        /// <returns></returns>
        public static AccessoryDto AccessoryMapToDto(Accessory accessory)
        {
            return new AccessoryDto()
            {
                Brand = accessory.Brand,
                Color = accessory.Color,
                ID = accessory.ID,
                ImmediateSending = accessory.ImmediateSending,
                Model = accessory.Model,
                Name = accessory.Name,
                Price = accessory.Price,
                Remaining = accessory.Remaining,
                SalesNumber = accessory.SalesNumber,
                Type = accessory.Type,
                Weight = accessory.Weight,
                Description = accessory.Description,
            };
        }


        public static AttachmentFileDto AttachmentFileMapToDto(AttachmentFile attachmentFile)
        {
            return new AttachmentFileDto()
            {
                Binary = attachmentFile.Binary,
                Description = attachmentFile.Description,
                Extension = attachmentFile.Extension,
                Id = attachmentFile.Id,
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
        public static AssembledCaseDto AssembledCaseMapToDto(AssembledCase assembledCase)
        {
            return new AssembledCaseDto()
            {
                Weight = assembledCase.Weight,
                Type = assembledCase.Type,
                SalesNumber = assembledCase.SalesNumber,
                Brand = assembledCase.Brand,
                Color = assembledCase.Color,
                CPU_Company = assembledCase.CPU_Company,
                ID = assembledCase.ID,
                ImmediateSending = assembledCase.ImmediateSending,
                IntrnalStorageType = assembledCase.IntrnalStorageType,
                Model = assembledCase.Model,
                Name = assembledCase.Name,
                Price = assembledCase.Price,
                RAM = assembledCase.RAM,
                Remaining = assembledCase.Remaining,
                Storage = assembledCase.Storage,
                AttachmentImageId = assembledCase.AttachmentImageId,
                Description = assembledCase.Description
            };
        }
        /// <summary>
        /// Map Comment to comment dto.
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public static CommentDto CommentMapToDto(Comment comment)
        {
            return new CommentDto()
            {
                Advantages = comment.Advantages,
                Content = comment.Content,
                DisAdvantages = comment.DisAdvantages,
                HasContent = comment.HasContent,
                ID = comment.ID,
                Name = comment.Name,
                SubmissionDate = comment.SubmissionDate,
                SuggestToFriends = comment.SuggestToFriends,
                Title = comment.Title,
                CommodityId = comment.CommodityId
            };
        }
        /// <summary>
        /// Map Commodity to dto.
        /// </summary>
        /// <param name="commodity"></param>
        /// <returns></returns>
        public static CommodityDto CommodityMapToDto(Commodity commodity)
        {
            return new CommodityDto()
            {
                ID = commodity.ID,
                Brand = commodity.Brand,
                Color = commodity.Color,
                ImmediateSending = commodity.ImmediateSending,
                Name = commodity.Name,
                Price = commodity.Price,
                Remaining = commodity.Remaining,
                SalesNumber = commodity.SalesNumber,
                Type = commodity.Type,
                Weight = commodity.Weight,
                AttachmentImageId = commodity.AttachmentImageId,
                CreatedTime = commodity.CreatedTime,
                Description = commodity.Description
            };
        }
        /// <summary>
        /// Map External hard to dto.
        /// </summary>
        /// <param name="externalHard"></param>
        /// <returns></returns>
        public static ExternalHardDto ExternalHardMapToDto(ExternalHard externalHard)
        {
            return new ExternalHardDto()
            {
                Weight = externalHard.Weight,
                Brand = externalHard.Brand,
                Color = externalHard.Color,
                ConnectionType = externalHard.ConnectionType,
                ID = externalHard.ID,
                ImmediateSending = externalHard.ImmediateSending,
                ImpactResistance = externalHard.ImpactResistance,
                Name = externalHard.Name,
                Price = externalHard.Price,
                Remaining = externalHard.Remaining,
                SalesNumber = externalHard.SalesNumber,
                StirageType = externalHard.StirageType,
                Type = externalHard.Type,
                WaterResistance = externalHard.WaterResistance,
                AttachmentImageId = externalHard.AttachmentImageId,
                Description = externalHard.Description
            };
        }
        /// <summary>
        /// Map Keyboard hard to dto.
        /// </summary>
        /// <param name="keyboard"></param>
        /// <returns></returns>
        public static KeyboardDto KeyboardMapToDto(Keyboard keyboard)
        {
            return new KeyboardDto()
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
                ID = keyboard.ID,
                ImmediateSending = keyboard.ImmediateSending,
                LiquidResistance = keyboard.LiquidResistance,
                MicrophoneInput = keyboard.MicrophoneInput,
                Name = keyboard.Name,
                Price = keyboard.Price,
                USB_Input = keyboard.USB_Input,
                Weight = keyboard.Weight,
                AttachmentImageId = keyboard.AttachmentImageId,
                Description = keyboard.Description
            };
        }
        /// <summary>
        /// Map laptop to dto.
        /// </summary>
        /// <param name="laptop"></param>
        /// <returns></returns>
        public static LaptopDto LaptopMapToDto(Laptop laptop)
        {
            return new LaptopDto()
            {
                Brand = laptop.Brand,
                Color = laptop.Color,
                CPU = laptop.CPU,
                GPU_Company = laptop.GPU_Company,
                GPU_Size = laptop.GPU_Size,
                ID = laptop.ID,
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
                Type = laptop.Type,
                Weight = laptop.Weight,
                AttachmentImageId = laptop.AttachmentImageId,
                Description = laptop.Description,
            };
        }
        /// <summary>
        /// Map Monile to Dto.
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static MobileDto MobileMapToDto(Mobile mobile)
        {
            return new MobileDto()
            {
                Weight = mobile.Weight,
                Type = mobile.Type,
                Brand = mobile.Brand,
                CameraResolution = mobile.CameraResolution,
                Color = mobile.Color,
                ID = mobile.ID,
                ImmediateSending = mobile.ImmediateSending,
                InternalStorage = mobile.InternalStorage,
                MobileRam = mobile.MobileRam,
                Model = mobile.Model,
                Name = mobile.Name,
                Network = mobile.Network,
                OS = mobile.OS,
                Price = mobile.Price,
                Remaining = mobile.Remaining,
                SalesNumber = mobile.SalesNumber,
                AttachmentImageId = mobile.AttachmentImageId,
                Description = mobile.Description
            };
        }
        /// <summary>
        /// Map Mobile Holder to Dto.
        /// </summary>
        /// <param name="mobileHolder"></param>
        /// <returns></returns>
        public static MobileHolderDto MobileHolderMapToDto(MobileHolder mobileHolder)
        {
            return new MobileHolderDto()
            {
                SalesNumber = mobileHolder.SalesNumber,
                Remaining = mobileHolder.Remaining,
                Price = mobileHolder.Price,
                Brand = mobileHolder.Brand,
                Color = mobileHolder.Color,
                ID = mobileHolder.ID,
                ImmediateSending = mobileHolder.ImmediateSending,
                Model = mobileHolder.Model,
                Name = mobileHolder.Name,
                Rechargeable = mobileHolder.Rechargeable,
                Rotate360 = mobileHolder.Rotate360,
                Type = mobileHolder.Type,
                Weight = mobileHolder.Weight,
                WirelessCharging = mobileHolder.WirelessCharging,
                AttachmentImageId = mobileHolder.AttachmentImageId,
                Description = mobileHolder.Description
            };
        }
        /// <summary>
        /// Map Mobile Cover to Dto.
        /// </summary>
        /// <param name="mobileCover"></param>
        /// <returns></returns>
        public static MobileCoverDto MobileCoverMapToDto(MobileCover mobileCover)
        {
            return new MobileCoverDto()
            {
                Weight = mobileCover.Weight,
                Brand = mobileCover.Brand,
                Color = mobileCover.Color,
                ForMobile = mobileCover.ForMobile,
                ID = mobileCover.ID,
                ImmediateSending = mobileCover.ImmediateSending,
                Material = mobileCover.Material,
                Model = mobileCover.Model,
                Name = mobileCover.Name,
                Price = mobileCover.Price,
                Remaining = mobileCover.Remaining,
                SalesNumber = mobileCover.SalesNumber,
                Size = mobileCover.Size,
                SpecialFeature = mobileCover.SpecialFeature,
                Type = mobileCover.Type,
                AttachmentImageId = mobileCover.AttachmentImageId,
                Description = mobileCover.Description
            };
        }
        /// <summary>
        /// Map Monitor to Dto.
        /// </summary>
        /// <param name="monitor"></param>
        /// <returns></returns>
        public static MonitorDto MonitorMapToDto(Monitor monitor)
        {
            return new MonitorDto()
            {
                Backlight = monitor.Backlight,
                Brand = monitor.Brand,
                Color = monitor.Color,
                DVI_Port = monitor.DVI_Port,
                HDMI_Port = monitor.HDMI_Port,
                ID = monitor.ID,
                ImmediateSending = monitor.ImmediateSending,
                Name = monitor.Name,
                PanelType = monitor.PanelType,
                Price = monitor.Price,
                Remaining = monitor.Remaining,
                Resolution = monitor.Resolution,
                ResponseTime = monitor.ResponseTime,
                SalesNumber = monitor.SalesNumber,
                Speaker = monitor.Speaker,
                Type = monitor.Type,
                USB_Port = monitor.USB_Port,
                Weight = monitor.Weight,
                AttachmentImageId = monitor.AttachmentImageId,
                Description = monitor.Description
            };
        }

        /// <summary>
        /// Map person to Dto.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public static PersonDto PersonMapToDto(Person person)
        {
            return new PersonDto()
            {
                Email = person.Email,
                FirstName = person.FirstName,
                ID = person.ID,
                IsLogin = person.IsLogin,
                IsRegister = person.IsRegister,
                LastName = person.LastName,
                MobileNumber = person.MobileNumber
            };
        }
        /// <summary>
        /// Map Power bank to Dto.
        /// </summary>
        /// <param name="powerBank"></param>
        /// <returns></returns>
        public static PowerBankDto PowerBankMapToDto(PowerBank powerBank)
        {
            return new PowerBankDto()
            {
                BodyMaterial = powerBank.BodyMaterial,
                Brand = powerBank.Brand,
                Capacity = powerBank.Capacity,
                Color = powerBank.Color,
                Flow = powerBank.Flow,
                ID = powerBank.ID,
                ImmediateSending = powerBank.ImmediateSending,
                Model = powerBank.Model,
                Name = powerBank.Name,
                OutputNumbers = powerBank.OutputNumbers,
                Price = powerBank.Price,
                Remaining = powerBank.Remaining,
                SalesNumber = powerBank.SalesNumber,
                SpecialFeatures = powerBank.SpecialFeatures,
                Type = powerBank.Type,
                Weight = powerBank.Weight,
                WeightClass = powerBank.WeightClass,
                AttachmentImageId = powerBank.AttachmentImageId,
                Description = powerBank.Description
            };
        }
        /// <summary>
        /// Map Promotion to Dto.
        /// </summary>
        /// <param name="promotion"></param>
        /// <returns></returns>
        public static PromotionDto PromotionMapToDto(Promotion promotion)
        {
            return new PromotionDto()
            {
                Type = promotion.Type,
                ID = promotion.ID,
                Percent = promotion.Percent,
                Status = promotion.Status
            };
        }
    }
}
