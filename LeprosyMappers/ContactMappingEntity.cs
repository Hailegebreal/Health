using System;
using AspNetCoreProject.LeprosyModel;
using AutoMapper;


namespace AspNetCoreProject.LeprosyMappers
{
    public class ContactMappingEntity:Profile
    {
        public ContactMappingEntity()
        {
            CreateMap<ContactViewModel, Contact>();

            CreateMap<Contact, ContactViewModel>()
                .ForMember(dnx=>dnx.SecurityNumber,(dsx)=> dsx.MapFrom(src=>src.SecurityNumber));
        }
    }
}
