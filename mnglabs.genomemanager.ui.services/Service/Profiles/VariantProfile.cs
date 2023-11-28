using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entities = mnglabs.genomemanager.ui.services.Data.Entities;
using mnglabs.genomemanager.ui.Shared;

namespace mnglabs.genomemanager.ui.services.Service.Profiles
{
    public class VariantProfile : Profile
    {
        public VariantProfile()
        {
            CreateMap<Entities.VariantDisplay, VariantDisplay>();
            CreateMap<Entities.FrequencyData, FrequencyData>();
            CreateMap<Entities.Transcript, Transcript>();
            CreateMap<Entities.UserLoginAttempt, UserLoginAttempt>();
            CreateMap<UserLoginAttempt, Entities.UserLoginAttempt>();
        }
    }
}
