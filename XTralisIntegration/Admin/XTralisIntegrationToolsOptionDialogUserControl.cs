using VideoOS.Platform.Admin;

namespace XTralisIntegration.Admin
{
    public partial class XTralisIntegrationToolsOptionDialogUserControl : ToolsOptionsDialogUserControl
    {
        public XTralisIntegrationToolsOptionDialogUserControl()
        {
            InitializeComponent();
        }

        public override void Init()
        {
        }

        public override void Close()
        {
        }

        public string MyPropValue
        {
            set { textBoxPropValue.Text = value ?? ""; }
            get { return textBoxPropValue.Text; }
        }
    }
}
