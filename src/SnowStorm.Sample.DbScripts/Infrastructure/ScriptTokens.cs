using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowStormSample.DbScripts.Infrastructure
{
    internal static class ScriptTokens
    {
        public const string Predeployment = "00_Predeployment";

        public const string DeployDbObjects = "01_DbObjects";

        //********** Other options *****************
        //public const string DeployDataAllEnvironments = "02_Data.All"
        //public const string DeployDataLocalDev = "02_Data.LocalDev"
        //public const string DeployDataTesting = "02_Data.Testing"
        //public const string DeployDataUat = "02_Data.Uat"
        //public const string DeployDataProduction = "02_Data.Production"
        //public const string DeployOnly = "03_Deploy_Only"
        //public const string TestOnly = "04_Test_Only"
        //public const string Rollback = "99_Rollback"  //TODO: Investigate rollback options and implementations
        //********** Other options *****************

        public enum DeploymentEnvironments
        {
            LocalDev,
            Testing,
            Uat,
            Production
        }
    }
}
