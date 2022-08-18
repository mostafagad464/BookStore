using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Authors
{
    public class Author : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; private set; }
        public DateTime BirthDate { get; set; }
        public string ShortBio { get; set; }

        public Author()
        {

        }

        internal Author (
                Guid id,
                [NotNull] string name,
                DateTime birthdate,
                [CanBeNull] string shortbio = null
            ) : base (id)
        {
            SetName (name);
            BirthDate = birthdate;
            ShortBio = shortbio;
        }


        internal Author ChangeName([NotNull] string name)
        {
            SetName (name);
            return this;
        }

        private void SetName([NotNull]  string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength: AuthorConsts.MaxNameLength
            );
        }
    }
}
