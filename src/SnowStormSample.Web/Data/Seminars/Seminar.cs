using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SnowStorm.Domain;
using SnowStorm.QueryExecutors;
using SnowStormSample.Shared.Dto;
using SnowStormSample.Shared.Errors;
using System;
using System.Threading.Tasks;

namespace SnowStormSample.Web.Data.Seminars
{
    public class Seminar : DomainEntityWithIdWithAudit
    {
        protected Seminar() { }

        public string? Subject { get; private set; }
        public DateTime EventDate { get; private set; }


        #region Methods

        internal static async Task<Seminar> Create(IQueryExecutor executor, SeminarDto data, bool autoSave = true)
        {
            if (data == null)
                throw new ValidationException("Create Failed due to missing data!: Seminar");

            var v = new Seminar(data);
            await executor.Add<Seminar>(v);

            if (autoSave)
                await executor.Save();

            return v;
        }

        private Seminar(SeminarDto data)
        {
            Save(data);
        }

        public void Save(SeminarDto data)
        {
            SetCreatedOn(data.CreatedOn);
            SetModifiedOn(data.ModifiedOn);
            SetSubject(data.Subject);
            SetEventDate(data.EventDate);

        }

        public void SetCreatedOn(DateTime v)
        {
            if (CreatedOn != v)
                CreatedOn = v;
        }

        public void SetModifiedOn(DateTime v)
        {
            if (ModifiedOn != v)
                ModifiedOn = v;
        }

        public void SetSubject(string? v)
        {
            if (string.IsNullOrWhiteSpace(v))
                throw new ValidationException("Subject must be provided");

            if (Subject != v)
                Subject = v;
        }

        public void SetEventDate(DateTime v)
        {
            if (EventDate != v)
                EventDate = v;
        }


        #endregion Methods


        #region Configuration
        internal class Mapping : IEntityTypeConfiguration<Seminar>
        {
            public void Configure(EntityTypeBuilder<Seminar> builder)
            {
                builder.ToTable("Seminar", "Seminars");
                builder.HasKey(u => u.Id);  // PK.
                builder.Property(p => p.Id).HasColumnName("Id");

                builder.Property(p => p.CreatedOn).IsRequired();
                builder.Property(p => p.ModifiedOn).IsRequired();
                builder.Property(p => p.Subject).HasMaxLength(128).IsRequired();
                builder.Property(p => p.EventDate).IsRequired();

            }
        }
        #endregion //config
    }


}
