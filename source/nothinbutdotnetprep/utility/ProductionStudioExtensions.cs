using System.Collections.Generic;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.utility
{
    public static class ProductionStudioExtensions
    {
        private static Dictionary<ProductionStudio, int> rankings = new Dictionary<ProductionStudio, int>
                                                                    {
                                                                        {ProductionStudio.MGM, 1},
                                                                        {ProductionStudio.Pixar, 2},
                                                                        {ProductionStudio.Dreamworks, 3},
                                                                        {ProductionStudio.Universal, 4},
                                                                        {ProductionStudio.Disney, 5},
                                                                        {ProductionStudio.Paramount, 6}
                                                                    };
        public static int GetRank(this ProductionStudio studio)
        {
            return rankings[studio];
        }
    }
}