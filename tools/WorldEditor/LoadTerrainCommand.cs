/********************************************************************

The Multiverse Platform is made available under the MIT License.

Copyright (c) 2012 The Multiverse Foundation

Permission is hereby granted, free of charge, to any person 
obtaining a copy of this software and associated documentation 
files (the "Software"), to deal in the Software without restriction, 
including without limitation the rights to use, copy, modify, 
merge, publish, distribute, sublicense, and/or sell copies 
of the Software, and to permit persons to whom the Software 
is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be 
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES 
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING 
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE 
OR OTHER DEALINGS IN THE SOFTWARE.

*********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Multiverse.Tools.WorldEditor
{
    public class LoadTerrainCommand : ICommand
    {
        protected String terrainFilename;
        protected bool populatedInstance = false;
        WorldEditor app;
        Axiom.SceneManagers.Multiverse.ITerrainGenerator undoTerrainGenerator;

        public LoadTerrainCommand(String filename, WorldEditor worldEditor)
        {
            app = worldEditor;
            populatedInstance = true;
            terrainFilename = filename;
        }

        #region ICommand Members

        public bool Undoable()
        {
            return true;
        }

        public void Execute()
        {
            // save old terrain object for undo
            undoTerrainGenerator = app.TerrainGenerator;

            // load the new terrain
            app.LoadMap(terrainFilename);
        }

        public void UnExecute()
        {
            if (undoTerrainGenerator != null)
            {
                app.TerrainGenerator = undoTerrainGenerator;
            }
        }

        #endregion
    }
}
