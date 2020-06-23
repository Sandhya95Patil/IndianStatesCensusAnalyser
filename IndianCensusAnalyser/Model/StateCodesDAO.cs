
namespace IndianCensusAnalyser.Model
{
    public class StateCodesDAO
    {
        public string StateName;
        public string StateCode;
       public StateCodesDAO(StatesCodeData statesCodeData) 
       {
            this.StateName = statesCodeData.StateName;
            this.StateCode = statesCodeData.StateCode;
       }
    }
}
