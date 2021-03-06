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

/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Shell.Flavor;
using System.Runtime.InteropServices;

namespace Microsoft.Samples.VisualStudio.IronPythonProject.WPFProviders
{
    [Guid(PythonWPFProjectFactory.PythonWPFProjectFactoryGuid)]
    public class PythonWPFProjectFactory : FlavoredProjectFactoryBase
    {
        public const string PythonWPFProjectFactoryGuid = "229B3E77-97E9-4f6d-9151-E6D103EA4D4A";

        private IServiceProvider site;
        public PythonWPFProjectFactory(IServiceProvider site)
            :base()
        {
            this.site = site;
        }

        /// <summary>
        /// Create an instance of our project. The initialization will be done later
        /// when VS calls InitalizeForOuter on it.
        /// </summary>
        /// <param name="outerProjectIUnknown">This is only useful if someone else is subtyping us</param>
        /// <returns>An uninitialized instance of our project</returns>
        protected override object PreCreateForOuter(IntPtr outerProjectIUnknown)
        {
            return new PythonWPFFlavor(site);
        }
    }
}
