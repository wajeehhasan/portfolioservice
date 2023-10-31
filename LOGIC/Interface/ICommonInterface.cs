using AutoMapper;
using DATA.Models;


namespace LOGIC.Interface
{
    public interface ICommonInterface<SourceResultSet, DestinationResultSet>
    {
        GenericResultSet<DestinationResultSet> convertResultSet<DestinationResultSet>(GenericResultSet<SourceResultSet> resultSet, IMapper _mapper);
    }
}
