using System.Collections.Generic;
using TEK.SeatPlan.BusinessLogic.Contract;
using TEK.SeatPlan.Entity;

namespace TEK.SeatPlan.BusinessLogic
{
    public class ProjectColorPairComponent : DataComponentBase, IProjectColorPairComponent
    {
        private readonly List<ProjectColorPair> colorsPairLibrary = new List<ProjectColorPair>();

        public ProjectColorPairComponent()
        {
            CreateColorLibrary();
        }

        private void CreateColorLibrary()
        {
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#856D72", BackgroundColor = "#CDA8AF" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#768B83", BackgroundColor = "#B5D6CA" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#6F8074", BackgroundColor = "#ABC5B3" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#898683", BackgroundColor = "#D3CEC9" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#647F8A", BackgroundColor = "#9AC3D4" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#797669", BackgroundColor = "#BBB6A1" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#9B9774", BackgroundColor = "#EFE8B3" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#8D9789", BackgroundColor = "#D9E8D3" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#81898A", BackgroundColor = "#C7D3D4" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#8D8578", BackgroundColor = "#D9CDB8" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#A39676", BackgroundColor = "#FAE7B6" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#778B77", BackgroundColor = "#B7D6B7" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#618787", BackgroundColor = "#95D0D0" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#889478", BackgroundColor = "#D1E3B8" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#9A7F8A", BackgroundColor = "#EDC4D4" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#839092", BackgroundColor = "#C5DADF" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#A28E72", BackgroundColor = "#F9DBAF" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#978E7B", BackgroundColor = "#E8DBBD" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#956A6A", BackgroundColor = "#E5A3A3" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#8E886A", BackgroundColor = "#DAD2A3" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#8C7A8C", BackgroundColor = "#D7BCD7" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#7F846A", BackgroundColor = "#C4CBA3" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#A39193", BackgroundColor = "#FADFE2" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#977065", BackgroundColor = "#E8AD9B" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#6F7A80", BackgroundColor = "#ABBCC5" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#949494", BackgroundColor = "#E3E3E3" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#7F7676", BackgroundColor = "#CEB8B8" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#707863", BackgroundColor = "#ACB999" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#7D817B", BackgroundColor = "#C0C7BE" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#678882", BackgroundColor = "#A6DBD1" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#908A8A", BackgroundColor = "#DDD4D5" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#7C928E", BackgroundColor = "#BFE0DB" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#7C736E", BackgroundColor = "#BFB1AA" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#7A7D8C", BackgroundColor = "#BCC1D8" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#9D8F89", BackgroundColor = "#F1DCD3" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#8C8A92", BackgroundColor = "#D7D5E1" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#999488", BackgroundColor = "#ECE3D1" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#8A7B74", BackgroundColor = "#D5BEB2" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#828385", BackgroundColor = "#C4C5C8" });
            colorsPairLibrary.Add(new ProjectColorPair() { ForegroundColor = "#9B7B7B", BackgroundColor = "#EEBEBE" });
        }
        public IEnumerable<ProjectColorPair> Get()
        {
            return colorsPairLibrary;
        }
    }
}