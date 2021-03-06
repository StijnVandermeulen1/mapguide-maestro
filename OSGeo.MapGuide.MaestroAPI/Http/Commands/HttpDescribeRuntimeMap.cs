﻿#region Disclaimer / License

// Copyright (C) 2013, Jackie Ng
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

using OSGeo.MapGuide.MaestroAPI.Commands;
using OSGeo.MapGuide.ObjectModels.RuntimeMap;

namespace OSGeo.MapGuide.MaestroAPI.Http.Commands
{
    internal class HttpDescribeRuntimeMap : IDescribeRuntimeMap
    {
        private readonly HttpServerConnection _conn;

        internal HttpDescribeRuntimeMap(HttpServerConnection conn)
        {
            _conn = conn;
            this.Name = null;
            this.RequestedFeatures = 0;
            this.IconWidth = 16;
            this.IconHeight = 16;
            this.IconFormat = "PNG"; //NOXLATE
            this.IconsPerScaleRange = 25;
        }

        public string Name
        {
            get;
            set;
        }

        public int RequestedFeatures
        {
            get;
            set;
        }

        public int IconsPerScaleRange
        {
            get;
            set;
        }

        public string IconFormat
        {
            get;
            set;
        }

        public int IconWidth
        {
            get;
            set;
        }

        public int IconHeight
        {
            get;
            set;
        }

        public IServerConnection Parent => _conn;

        public IRuntimeMapInfo Execute()
        {
            return _conn.DescribeRuntimeMap(
                this.Name,
                this.RequestedFeatures,
                this.IconsPerScaleRange,
                this.IconFormat,
                this.IconWidth,
                this.IconHeight);
        }
    }
}