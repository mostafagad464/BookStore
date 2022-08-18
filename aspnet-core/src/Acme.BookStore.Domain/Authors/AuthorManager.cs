using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Acme.BookStore.Authors
{
    public class AuthorManager : DomainService
    {
        private readonly IAuthorRepository _authorrepository;

        public AuthorManager(IAuthorRepository authorrepository)
        {
            _authorrepository = authorrepository;
        }

        public async Task<Author> CreateAsync(
                [NotNull] string name,
                DateTime birthDate,
                [CanBeNull] string shortBio = null
            )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingAuthor = await _authorrepository.FindByNameAsync(name);
            if(existingAuthor != null)
            {
                throw new AuthorAleadyExistsExeption(name);
            }
            return new Author(
                GuidGenerator.Create(),
                name,
                birthDate,
                shortBio
            );
        }

        public async Task ChangeNameAsync([NotNull] Author author, [NotNull] string newName)
        {
            Check.NotNull(author, nameof(author));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingAuthor = await _authorrepository.FindByNameAsync(newName);
            if(existingAuthor != null && existingAuthor.Id != author.Id)
            {
                throw new AuthorAleadyExistsExeption(newName);
            }
            author.ChangeName(newName);
        }
    }
}
