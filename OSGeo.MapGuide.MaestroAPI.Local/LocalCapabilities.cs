﻿#region Disclaimer / License

// Copyright (C) 2010, Jackie Ng
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

using OSGeo.MapGuide.MaestroAPI.Capability;
using OSGeo.MapGuide.MaestroAPI.Commands;
using OSGeo.MapGuide.ObjectModels;
using System;

namespace OSGeo.MapGuide.MaestroAPI.Local
{
    public class LocalCapabilities : ConnectionCapabilities
    {
        internal LocalCapabilities(IServerConnection parent)
            : base(parent)
        {
        }

        public override int[] SupportedCommands
        {
            get
            {
                if (_parent.SiteVersion >= new Version(2, 2))
                {
                    //TODO: Work out what this can/can't do
                    return new int[]
                    {
                        (int)CommandType.GetResourceContents
                    };
                }
                else
                {
                    //TODO: Work out what this can/can't do
                    return new int[]
                    {
                    };
                }
            }
        }

        public override bool IsSupportedResourceType(string resourceType) 
            => resourceType != ResourceTypes.ApplicationDefinition.ToString() && 
               resourceType != ResourceTypes.WebLayout.ToString();

        public override bool SupportsResourcePreviews => true;

        public override bool IsMultithreaded => false;

        public override bool SupportsResourceReferences => false;

        public override bool SupportsResourceSecurity => false;

        public override bool SupportsWfsPublishing => false;

        public override bool SupportsWmsPublishing => false;

        public override bool SupportsResourceHeaders => false;
    }
}