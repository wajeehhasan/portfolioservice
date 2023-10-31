using AutoMapper;
using DATA.Models;
using LOGIC.Interface;


namespace LOGIC.Implementation
{
    public class CommonService<SourceResultSet, DestinationResultSet> : ICommonInterface<SourceResultSet, DestinationResultSet>
    {
        public DATA.Models.GenericResultSet<DestinationResultSet> convertResultSet<DestinationResultSet>(DATA.Models.GenericResultSet<SourceResultSet> sourceResultSet,IMapper _mapper)
        {
            GenericResultSet<DestinationResultSet> returnResultSet = new(){
                status = sourceResultSet.status,
                message = sourceResultSet.message,
                resultSet = _mapper.Map<DestinationResultSet>(sourceResultSet.resultSet)
        };
            return returnResultSet;
        }
    }
}
