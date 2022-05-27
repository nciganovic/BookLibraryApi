using Application.Dto.Publisher;
using Application.Queries.Publishers;
using AutoMapper;
using DataAccess;
using Domain;
using System;

namespace Implementation.Queries.PublisherQueries
{
    public class EfGetOnePublisherQuery : BaseQuery<Publisher>, IGetOnePublisherQuery
    {
        private IMapper _mapper;

        public EfGetOnePublisherQuery(BookLibraryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 44;

        public string Name => "Get one publisher";

        public PublisherResultDto Execute(int search)
        {


            throw new Exception();
        }
    }
}
