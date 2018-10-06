using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using WebApi.DataModels;
using WebApi.DataModels.GenericRepository;

namespace WebApi.DataModels.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        #region Private member variables...

        private ApplicationDbContext _context = null;
        private GenericRepository<Value> _valueRepository;
        #endregion

        public UnitOfWork()
        {            
            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            options.UseInMemoryDatabase("InMemoryDb");
            _context = new ApplicationDbContext(options.Options);
        }

        #region Public Repository Creation properties...


        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<Value> ValueRepository
        {
            get
            {
                if (this._valueRepository == null)
                    this._valueRepository = new GenericRepository<Value>(_context);
                return _valueRepository;
            }
        }

        #endregion

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
/* 
                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, 
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines); */

                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false; 
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 
        #endregion
    }
}