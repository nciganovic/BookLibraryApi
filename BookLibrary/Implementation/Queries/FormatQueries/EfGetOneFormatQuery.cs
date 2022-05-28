using Application.Dto.Format;
using Application.Queries.Format;
using AutoMapper;
using DataAccess;
using Domain;
using System;

namespace Implementation.Queries.FormatQueries
{
    public class EfGetOneFormatQuery : BaseQuery<Format>, IGetOneFormatQuery
    {
        private IMapper _mapper;

        public EfGetOneFormatQuery(BookLibraryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 54;

        public string Name => "Get one format";

        public FormatResultDto Execute(int search)
        {
            Format format = context.Formats.Find(search);
            if (format?.DeletedAt != null)
                return null;
            return _mapper.Map<Format, FormatResultDto>(format);
        }
    }
}
