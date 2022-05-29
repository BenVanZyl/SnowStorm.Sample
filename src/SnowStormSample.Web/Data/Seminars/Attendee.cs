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
    public class Atendee : DomainEntityWithIdWithAudit
    {
        protected Atendee() { }

        public long SeminarId { get; private set; }
        public string? AttendeeName { get; private set; }

        #region Methods

        internal static async Task<Atendee> Create(IQueryExecutor executor, AtendeeDto data, bool autoSave = true)
        {
            if (data == null)
                throw new ValidationException("Create Failed due to missing data!: Atendee");

            var v = new Atendee(data);
            await executor.Add<Atendee>(v);

            if (autoSave)
                await executor.Save();

            return v;
        }

        private Atendee(AtendeeDto data)
        {
            Save(data);
        }

        public void Save(AtendeeDto data)
        {
            SetSeminarId(data.SeminarId);
            SetAttendeeName(data.AttendeeName);
        }

        public void SetSeminarId(long v)
        {
            if (SeminarId != v)
                SeminarId = v;
        }

        public void SetAttendeeName(string? v)
        {
            if (string.IsNullOrWhiteSpace(v))
                throw new ValidationException("Atendee Name must be provided");

            if (AttendeeName != v)
                AttendeeName = v;
        }


        #endregion Methods


        #region Configuration
        internal class Mapping : IEntityTypeConfiguration<Atendee>
        {
            public void Configure(EntityTypeBuilder<Atendee> builder)
            {
                builder.ToTable("Atendee", "Seminars");
                builder.HasKey(u => u.Id);  // PK.
                builder.Property(p => p.Id).HasColumnName("Id");

                builder.Property(p => p.CreatedOn).IsRequired();
                builder.Property(p => p.ModifiedOn).IsRequired();
                builder.Property(p => p.AttendeeName).HasMaxLength(128).IsRequired();

            }
        }
        #endregion //config
    }


}
