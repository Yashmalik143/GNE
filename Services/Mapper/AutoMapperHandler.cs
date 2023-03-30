using AutoMapper;
using DataAccess.Entity;
using Services.DTOClass;

namespace Services.Mapper
{
    public class AutoMapperHandler:Profile
    {
        public AutoMapperHandler()
        {
            CreateMap<Currency, CurrencyDTO>().ReverseMap();
            CreateMap<Category, CategoryTypeDTO>().ReverseMap();
            CreateMap<CounterParty, CounterPartyDTO>().ReverseMap();
            CreateMap<User,UserDTO>().ReverseMap();
            CreateMap<Threshold, ThresholdDTO>().ReverseMap();
            CreateMap<ReceiverModel, ReceiverModelDTO>().ReverseMap();
            CreateMap<ReceiverRecipientDTO,ReceiverRecipient>().ReverseMap();
            CreateMap<ReceiverDetail,ReceiverDetailsDTO>().ReverseMap();
            CreateMap<ReceiverAttachment,ReceiverAttachmentDTO>().ReverseMap();
            CreateMap<GiverRecipient, GiverRecipientDTO>().ReverseMap();
            CreateMap<GiverModel, GiverDTO>().ReverseMap();
            CreateMap<GivenDetail, GiverDetailDTO>().ReverseMap();
            CreateMap<GiverAttachmentDTO,GiverAttachment>().ReverseMap();
        }
    }
}
