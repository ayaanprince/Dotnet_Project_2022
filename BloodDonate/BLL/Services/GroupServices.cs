using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace BLL.Services
{
    public class GroupServices
    {
        public static List<GroupDTO> Get()
        {
            var lst = DataAccessFactory.GroupDataAccess().Get();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Group, GroupDTO>(); });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<GroupDTO>>(lst);
            return converted;
        }
        public static GroupDTO Get(int id)
        {
            var data = DataAccessFactory.GroupDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Group, GroupDTO>(); });
            var mapper = new Mapper(config);
            var converted = mapper.Map<GroupDTO>(data);
            return converted;
        }
        public static GroupDTO Add(GroupDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<GroupDTO, Group>();
                cfg.CreateMap<Group, GroupDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<Group>(obj);
            var res = DataAccessFactory.GroupDataAccess().Add(converted);
            return mapper.Map<GroupDTO>(res);
        }
    }
}
