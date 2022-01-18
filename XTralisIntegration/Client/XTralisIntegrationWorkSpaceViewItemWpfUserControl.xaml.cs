using System;
using VideoOS.Platform.Client;

namespace XTralisIntegration.Client
{
    /// <summary>
    /// Interaction logic for XTralisIntegrationWorkSpaceViewItemWpfUserControl.xaml
    /// </summary>
    public partial class XTralisIntegrationWorkSpaceViewItemWpfUserControl : ViewItemWpfUserControl
    {
        public XTralisIntegrationWorkSpaceViewItemWpfUserControl()
        {
            InitializeComponent();
        }

        public override void Init()
        {
        }

        public override void Close()
        {
        }

        /// <summary>
        /// Do not show the sliding toolbar!
        /// </summary>
        public override bool ShowToolbar
        {
            get { return false; }
        }

        private void ViewItemWpfUserControl_ClickEvent(object sender, EventArgs e)
        {
            FireClickEvent();
        }

        private void ViewItemWpfUserControl_DoubleClickEvent(object sender, EventArgs e)
        {
            FireDoubleClickEvent();
        }
    }
}
