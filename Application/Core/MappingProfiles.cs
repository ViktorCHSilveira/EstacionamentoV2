﻿using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core {
    public class MappingProfiles : Profile {

        public MappingProfiles() {

            CreateMap<Establishment, Establishment>();
            CreateMap<Domain.Entities.Vehicle, Domain.Entities.Vehicle>();
            
        }
    }
}
