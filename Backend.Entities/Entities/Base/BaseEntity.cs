﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public abstract class BaseEntity
    {
        bool disposed = false;

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool IsDeactivate { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        protected BaseEntity()
        {
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here. 
            }

            // Free any unmanaged objects here. 
            disposed = true;
        }

        ~BaseEntity()
        {
            Dispose(false);
        }

        public virtual BaseEntity Copy()
        {
            return (BaseEntity)MemberwiseClone();
        }
    }
}
