using System;
using System.Collections.Generic;
using VideoOS.Platform;
using VideoOS.Platform.Client;

namespace XTralisIntegration.Client
{
    class XTralisIntegrationViewItemToolbarPluginInstance : ViewItemToolbarPluginInstance
    {
        private Item _viewItemInstance;
        private Item _window;

        public override void Init(Item viewItemInstance, Item window)
        {
            _viewItemInstance = viewItemInstance;
            _window = window;

            Title = "XTralisIntegration";
            Tooltip = "XTralisIntegration tooltip";
        }

        public override void Activate()
        {
            // Here you should put whatever action that should be executed when the toolbar button is pressed
        }

        public override void Close()
        {
        }
    }

    class XTralisIntegrationViewItemToolbarPlugin : ViewItemToolbarPlugin
    {
        public override Guid Id
        {
            get { return XTralisIntegrationDefinition.XTralisIntegrationViewItemToolbarPluginId; }
        }

        public override string Name
        {
            get { return "XTralisIntegration"; }
        }

        public override ToolbarPluginOverflowMode ToolbarPluginOverflowMode
        {
            get { return ToolbarPluginOverflowMode.AsNeeded; }
        }

        public override void Init()
        {
            // TODO: remove below check when XTralisIntegrationDefinition.XTralisIntegrationViewItemToolbarPluginId has been replaced with proper GUID
            if (Id == new Guid("33333333-3333-3333-3333-333333333333"))
            {
                System.Windows.MessageBox.Show("Default GUID has not been replaced for XTralisIntegrationViewItemToolbarPluginId!");
            }

            ViewItemToolbarPlaceDefinition.ViewItemIds = new List<Guid>() { ViewAndLayoutItem.CameraBuiltinId };
            ViewItemToolbarPlaceDefinition.WorkSpaceIds = new List<Guid>() { ClientControl.LiveBuildInWorkSpaceId, ClientControl.PlaybackBuildInWorkSpaceId, XTralisIntegrationDefinition.XTralisIntegrationWorkSpacePluginId };
            ViewItemToolbarPlaceDefinition.WorkSpaceStates = new List<WorkSpaceState>() { WorkSpaceState.Normal };
        }

        public override void Close()
        {
        }

        public override ViewItemToolbarPluginInstance GenerateViewItemToolbarPluginInstance()
        {
            return new XTralisIntegrationViewItemToolbarPluginInstance();
        }
    }
}
