using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Models;
using Repository.BaseRepository;

namespace Repository.UnitOfWork
{
    public class DataContext : IDisposable
    {
        private readonly DigiDataBase _context;

        public DataContext()
        {
            _context = new DigiDataBase();
        }

        private BaseRepository<Setting> _settingRepository;
        public BaseRepository<Setting> SettingRepository => _settingRepository ?? (_settingRepository = new BaseRepository<Setting>(_context));

        private BaseRepository<Commodity> _commodityRepository;
        public BaseRepository<Commodity> CommodityRepository => _commodityRepository ?? (_commodityRepository = new BaseRepository<Commodity>(_context));

        private BaseRepository<Accessory> _accessoryRepository;
        public BaseRepository<Accessory> AccessoryRepository => _accessoryRepository ?? (_accessoryRepository = new BaseRepository<Accessory>(_context));

        private BaseRepository<AttachmentFile> _attachmentFileRepository;
        public BaseRepository<AttachmentFile> AttachmentFileRepository => _attachmentFileRepository ?? (_attachmentFileRepository = new BaseRepository<AttachmentFile>(_context));


        private BaseRepository<Comment> _commentRepository;
        public BaseRepository<Comment> CommentRepository => _commentRepository ?? (_commentRepository = new BaseRepository<Comment>(_context));

        private BaseRepository<AssembledCase> _assembledCaseRepository;
        public BaseRepository<AssembledCase> AssembledCaseRepository => _assembledCaseRepository ?? (_assembledCaseRepository = new BaseRepository<AssembledCase>(_context));

        private BaseRepository<ComputersAndAccessory> _computersAndAccessoryRepository;
        public BaseRepository<ComputersAndAccessory> ComputersAndAccessoryRepository => _computersAndAccessoryRepository ??
            (_computersAndAccessoryRepository = new BaseRepository<ComputersAndAccessory>(_context));

        private BaseRepository<ExternalHard> _externalHardRepository;
        public BaseRepository<ExternalHard> ExternalHardRepository => _externalHardRepository ?? (_externalHardRepository = new BaseRepository<ExternalHard>(_context));

        private BaseRepository<Keyboard> _keyboardRepository;
        public BaseRepository<Keyboard> keyboardRepository => _keyboardRepository ?? (_keyboardRepository = new BaseRepository<Keyboard>(_context));

        private BaseRepository<Laptop> _laptopsRepository;
        public BaseRepository<Laptop> LaptopsRepository => _laptopsRepository ?? (_laptopsRepository = new BaseRepository<Laptop>(_context));

        private BaseRepository<Mobile> _mobileRepository;
        public BaseRepository<Mobile> MobileRepository => _mobileRepository ?? (_mobileRepository = new BaseRepository<Mobile>(_context));

        private BaseRepository<MobileCover> _mobileCoverRepository;
        public BaseRepository<MobileCover> MobileCoverRepository => _mobileCoverRepository ?? (_mobileCoverRepository = new BaseRepository<MobileCover>(_context));

        private BaseRepository<MobileHolder> _mobileHolderRepository;
        public BaseRepository<MobileHolder> MobileHolderRepository => _mobileHolderRepository ?? (_mobileHolderRepository = new BaseRepository<MobileHolder>(_context));

        private BaseRepository<Monitor> _monitorRepository;
        public BaseRepository<Monitor> MonitorRepository => _monitorRepository ?? (_monitorRepository = new BaseRepository<Monitor>(_context));

        private BaseRepository<Person> _personRepository;
        public BaseRepository<Person> PersonRepository => _personRepository ?? (_personRepository = new BaseRepository<Person>(_context));

        private BaseRepository<PostedComment> _postedCommentRepository;
        public BaseRepository<PostedComment> postedCommentRepository => _postedCommentRepository ?? (_postedCommentRepository = new BaseRepository<PostedComment>(_context));

        private BaseRepository<Promotion> _promotionRepository;
        public BaseRepository<Promotion> PromotionRepository => _promotionRepository ?? (_promotionRepository = new BaseRepository<Promotion>(_context));
        
        private BaseRepository<PowerBank> _powerBankRepository;
        public BaseRepository<PowerBank> PowerBankRepository => _powerBankRepository ?? (_powerBankRepository = new BaseRepository<PowerBank>(_context));

        /// <summary>
        /// Save all changes
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Reload(object obj)
        {
            _context.Entry(obj).Reload();
        }
    }
}
