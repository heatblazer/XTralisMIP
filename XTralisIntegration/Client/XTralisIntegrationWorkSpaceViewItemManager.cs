using VideoOS.Platform.Client;

namespace XTralisIntegration.Client
{
    public class XTralisIntegrationWorkSpaceViewItemManager : ViewItemManager
    {
        public XTralisIntegrationWorkSpaceViewItemManager() : base("XTralisIntegrationWorkSpaceViewItemManager")
        {
        }

        public override ViewItemWpfUserControl GenerateViewItemWpfUserControl()
        {
            return new XTralisIntegrationWorkSpaceViewItemWpfUserControl();
        }
    }
}
