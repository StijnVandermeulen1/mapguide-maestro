﻿#region Disclaimer / License

// Copyright (C) 2012, Jackie Ng
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

using ICSharpCode.Core;
using Maestro.Editors.Diff;
using Maestro.Shared.UI;
using OSGeo.MapGuide.MaestroAPI.Resource.Comparison;
using System;
using System.IO;
using System.Windows.Forms;

namespace Maestro.Base.Commands
{
    internal class ViewXmlChangesCommand : AbstractMenuCommand
    {
        public override void Run()
        {
            var wb = Workbench.Instance;
            if (wb == null) return;
            var ed = wb.ActiveEditor;
            if (ed == null) return;
            var edSvc = ed.EditorService;

            TextFileDiffList sLF = null;
            TextFileDiffList dLF = null;
            string sourceFile = null;
            string targetFile = null;
            try
            {
                ed.SyncSessionCopy();
                var set = XmlCompareUtil.PrepareForComparison(edSvc.CurrentConnection.ResourceService,
                                                              edSvc.ResourceID,
                                                              edSvc.EditedResourceID);
                sLF = set.Source;
                dLF = set.Target;
            }
            catch (Exception ex)
            {
                ErrorDialog.Show(ex);
                return;
            }
            finally
            {
                try { File.Delete(sourceFile); }
                catch { }
                try { File.Delete(targetFile); }
                catch { }
            }

            try
            {
                double time = 0;
                DiffEngine de = new DiffEngine();
                time = de.ProcessDiff(sLF, dLF, DiffEngineLevel.SlowPerfect);

                var rep = de.DiffReport();
                TextDiffView dlg = new TextDiffView(sLF, dLF, rep, time);
                dlg.SetLabels(edSvc.ResourceID, Strings.EditedResource);
                dlg.ShowDialog();
                dlg.Dispose();
            }
            catch (Exception ex)
            {
                string nl = Environment.NewLine;
                string tmp = $"{ex.Message}{nl}{nl}***STACK***{nl}{ex.StackTrace}";
                MessageBox.Show(tmp, Strings.CompareError);
                return;
            }
        }
    }
}