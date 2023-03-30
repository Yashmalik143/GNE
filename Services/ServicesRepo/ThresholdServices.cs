using AutoMapper;
using DataAccess.Entity;
using DataAccess.IDataAcces;
using Services.DTOClass;
using Services.ServicesInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesRepo
{
    public class ThresholdServices : IThresholdServices
    {
        private readonly IThreshold _threshold;
        private readonly IMapper _mapper;
        public ThresholdServices(IThreshold threshold,IMapper mapper)
        {
            _threshold = threshold;
            _mapper = mapper;
        }
        public async Task<List<ThresholdDTO>> GetListOfThreshold()
        {
            var listOFThreshold=await _threshold.GetAllThresholdList();
            var dtoToClass = _mapper.Map<List<Threshold>, List<ThresholdDTO>>(listOFThreshold);
            return dtoToClass;
        }
    }
}
