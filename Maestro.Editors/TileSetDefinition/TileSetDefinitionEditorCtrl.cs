﻿#region Disclaimer / License

// Copyright (C) 2015, Jackie Ng
// https://github.com/jumpinjackie/mapguide-maestro
//
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
//

#endregion Disclaimer / License

namespace Maestro.Editors.TileSetDefinition
{
    /// <summary>
    /// The Tile Set Definition editor control
    /// </summary>
    public partial class TileSetDefinitionEditorCtrl : EditorBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public TileSetDefinitionEditorCtrl()
        {
            InitializeComponent();
        }

        private IEditorService _edSvc;

        /// <summary>
        /// Sets the initial state of this editor and sets up any databinding
        /// within such that user interface changes will propagate back to the
        /// model.
        /// </summary>
        /// <param name="service"></param>
        public override void Bind(IEditorService service)
        {
            _edSvc = service;
            _edSvc.RegisterCustomNotifier(this);

            tileSetSettingsCtrl.Bind(_edSvc);
            layerStructureCtrl.Bind(_edSvc);
            layerStructureCtrl.RequestLayerOpen += OnRequestLayerOpen;
        }

        private void OnRequestLayerOpen(object sender, string layerResourceId)
        {
            _edSvc.OpenResource(layerResourceId);
        }
    }
}
