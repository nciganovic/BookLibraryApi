using Application.Dto.Language;
using Application.Queries.Language;
using AutoMapper;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.LanguageQueries
{
    public class EfGetOneLanguageQuery : BaseQuery<Language>, IGetOneLanguageQuery
    {
        private IMapper _mapper;

        public EfGetOneLanguageQuery(BookLibraryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 34;

        public string Name => "Get one language";

        public LanguageResultDto Execute(int search)
        {
            Language language = context.Languages.Find(search);
            if (language?.DeletedAt != null)
                return null;
            return _mapper.Map<Language, LanguageResultDto>(language);
        }
    }
}
