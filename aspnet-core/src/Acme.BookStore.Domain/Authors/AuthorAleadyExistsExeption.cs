using System;
using System.Runtime.Serialization;
using Volo.Abp;

namespace Acme.BookStore.Authors
{
    [Serializable]
    internal class AuthorAleadyExistsExeption : BusinessException
    {

        public AuthorAleadyExistsExeption(string name) : base(BookStoreDomainErrorCodes.AuthorAlreadyExists)
        {
            WithData("name", name);
        }

    }
}