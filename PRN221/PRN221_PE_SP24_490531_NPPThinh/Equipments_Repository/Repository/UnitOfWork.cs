using Equipments_Repository.Models;
using Equipments_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Equipments_Repository.Repository
{
    public class UnitOfWork : IDisposable
    {
        private readonly Equipments2024DbContext _dbContext;
        private GenericRepository<Account> _accountRepository;
        private GenericRepository<Equipment> _equipmentRepository;
        private GenericRepository<Room> _roomRepository;

        public UnitOfWork(Equipments2024DbContext dbContext
        )
        {
            _dbContext = dbContext;
        }

        public GenericRepository<Account> AccountRepository
        {
            get
            {
                if (_accountRepository == null)
                {
                    _accountRepository = new GenericRepository<Account>(_dbContext);
                }
                return _accountRepository;
            }
        }

        public GenericRepository<Equipment> EquipmentRepository
        {
            get
            {
                if (_equipmentRepository == null)
                {
                    _equipmentRepository = new GenericRepository<Equipment>(_dbContext);
                }
                return _equipmentRepository;
            }
        }

        public GenericRepository<Room> RoomRepository
        {
            get
            {
                if (_roomRepository == null)
                {
                    _roomRepository = new GenericRepository<Room>(_dbContext);
                }
                return _roomRepository;
            }
        }

        public int SaveChange()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
