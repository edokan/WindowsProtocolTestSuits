// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Protocols.TestSuites.FileSharing.FSA.TestSuite {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Reflection;
    using Microsoft.SpecExplorer.Runtime.Testing;
    using Microsoft.Protocols.TestTools;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Spec Explorer", "3.5.3146.0")]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class WriteFileTestCase : PtfTestClassBase {
        
        public WriteFileTestCase() {
            this.SetSwitch("ProceedControlTimeout", "100");
            this.SetSwitch("QuiescenceTimeout", "2000000");
        }
        
        #region Adapter Instances
        private Microsoft.Protocols.TestSuites.FileSharing.FSA.Adapter.IFSAAdapter IFSAAdapterInstance;
        #endregion
        
        #region Class Initialization and Cleanup
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void ClassInitialize(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext context) {
            PtfTestClassBase.Initialize(context);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void ClassCleanup() {
            PtfTestClassBase.Cleanup();
        }
        #endregion
        
        #region Test Initialization and Cleanup
        protected override void TestInitialize() {
            this.InitializeTestManager();
            this.IFSAAdapterInstance = ((Microsoft.Protocols.TestSuites.FileSharing.FSA.Adapter.IFSAAdapter)(this.Manager.GetAdapter(typeof(Microsoft.Protocols.TestSuites.FileSharing.FSA.Adapter.IFSAAdapter))));
        }
        
        protected override void TestCleanup() {
            base.TestCleanup();
            this.CleanupTestManager();
        }
        #endregion
        
        #region Test Starting in S0
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategory(Microsoft.Protocols.TestSuites.FileSharing.Common.Adapter.TestCategories.Model)]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategory(Microsoft.Protocols.TestSuites.FileSharing.Common.Adapter.TestCategories.Fsa)]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategory(Microsoft.Protocols.TestSuites.FileSharing.Common.Adapter.TestCategories.WriteFile)]
        public void WriteFileTestCaseS0() {
            this.Manager.BeginTest("WriteFileTestCaseS0");
            this.Manager.Comment("reaching state \'S0\'");
            this.Manager.Comment("executing step \'call FsaInitial()\'");
            this.IFSAAdapterInstance.FsaInitial();
            this.Manager.Comment("reaching state \'S1\'");
            this.Manager.Comment("checking step \'return FsaInitial\'");
            this.Manager.Comment("reaching state \'S2\'");
            Microsoft.Protocols.TestSuites.FileSharing.FSA.Adapter.SSecurityContext temp0;
            this.Manager.Comment("executing step \'call GetSystemConfig(out _)\'");
            this.IFSAAdapterInstance.GetSystemConfig(out temp0);
            this.Manager.Comment("reaching state \'S3\'");
            this.Manager.Comment("checking step \'return GetSystemConfig/[out SSecurityContext(privilegeSet=SeRestor" +
                    "ePrivilege,isSecurityContextSIDsContainWellKnown=False,isImplementsEncryption=Fa" +
                    "lse)]\'");
            TestManagerHelpers.AssertAreEqual<Microsoft.Protocols.TestSuites.FileSharing.FSA.Adapter.SSecurityContext>(this.Manager, this.Make<Microsoft.Protocols.TestSuites.FileSharing.FSA.Adapter.SSecurityContext>(new string[] {
                            "privilegeSet",
                            "isSecurityContextSIDsContainWellKnown",
                            "isImplementsEncryption"}, new object[] {
                            Microsoft.Protocols.TestSuites.FileSharing.FSA.Adapter.PrivilegeSet.SeRestorePrivilege,
                            false,
                            false}), temp0, "securityContext of GetSystemConfig, state S3");
            this.Manager.Comment("reaching state \'S4\'");
            bool temp1;
            this.Manager.Comment("executing step \'call GetIfOpenFileVolumeIsReadOnly(out _)\'");
            this.IFSAAdapterInstance.GetIfOpenFileVolumeIsReadOnly(out temp1);
            this.Manager.Comment("reaching state \'S5\'");
            this.Manager.Comment("checking step \'return GetIfOpenFileVolumeIsReadOnly/[out False]\'");
            TestManagerHelpers.AssertAreEqual<bool>(this.Manager, false, temp1, "isReadOnly of GetIfOpenFileVolumeIsReadOnly, state S5");
            this.Manager.Comment("reaching state \'S6\'");
            Microsoft.Protocols.TestSuites.FileSharing.FSA.Adapter.MessageStatus temp2;
            this.Manager.Comment("executing step \'call CreateFile(NORMAL,NO_INTERMEDIATE_BUFFERING,NULL,MAXIMUM_ALL" +
                    "OWED,FILE_SHARE_WRITE,CREATE,StreamIsFound,IsNotSymbolicLink,DataFile,Normal)\'");
            temp2 = this.IFSAAdapterInstance.CreateFile(Microsoft.Protocols.TestSuites.FileSharing.FSA.Adapter.FileAttribute.NORMAL, Microsoft.Protocols.TestSuites.FileSharing.FSA.Adapter.CreateOptions.NO_INTERMEDIATE_BUFFERING, Microsoft.Protocols.TestSuites.FileSharing.FSA.Adapter.StreamTypeNameToOpen.NULL, Microsoft.Protocols.TestSuites.FileSharing.FSA.Adapter.FileAccess.MAXIMUM_ALLOWED, Microsoft.Protocols.TestSuites.FileSharing.FSA.Adapter.ShareAccess.FILE_SHARE_WRITE, Microsoft.Protocols.TestSuites.FileSharing.FSA.Adapter.CreateDisposition.CREATE, ((Microsoft.Protocols.TestSuites.FileSharing.FSA.Adapter.StreamFoundType)(0)), ((Microsoft.Protocols.TestSuites.FileSharing.FSA.Adapter.SymbolicLinkType)(1)), ((Microsoft.Protocols.TestSuites.FileSharing.FSA.Adapter.FileType)(0)), Microsoft.Protocols.TestSuites.FileSharing.FSA.Adapter.FileNameStatus.Normal);
            this.Manager.Checkpoint("MS-FSA_R405");
            this.Manager.Checkpoint(@"[In Application Requests an Open of a File , Pseudocode for the operation is as follows:
                        Phase 6 -- Location of file:] Pseudocode for this search:For i = 1 to n-1:
                        If Open.GrantedAccess.FILE_TRAVERSE is not set and AccessCheck( SecurityContext, Link.File.SecurityDescriptor, FILE_TRAVERSE ) 
                        returns FALSE, the operation is not  failed with STATUS_ACCESS_DENIED in Windows.");
            this.Manager.Checkpoint("MS-FSA_R475");
            this.Manager.Checkpoint("[In Creation of a New File,Pseudocode for the operation is as follows:]\r\n        " +
                    "        The object store MUST return:CreateAction set to FILE_CREATED.");
            this.Manager.Checkpoint("MS-FSA_R474");
            this.Manager.Checkpoint("[In Creation of a New File,Pseudocode for the operation is as follows:]\r\n        " +
                    "        The object store MUST return :Status set to STATUS_SUCCESS.");
            this.Manager.Comment("reaching state \'S7\'");
            this.Manager.Comment("checking step \'return CreateFile/SUCCESS\'");
            TestManagerHelpers.AssertAreEqual<Microsoft.Protocols.TestSuites.FileSharing.FSA.Adapter.MessageStatus>(this.Manager, ((Microsoft.Protocols.TestSuites.FileSharing.FSA.Adapter.MessageStatus)(0)), temp2, "return of CreateFile, state S7");
            this.Manager.Comment("reaching state \'S8\'");
            long temp3;
            this.Manager.Comment("executing step \'call GetFileVolumSize(out _)\'");
            this.IFSAAdapterInstance.GetFileVolumSize(out temp3);
            this.Manager.Comment("reaching state \'S9\'");
            this.Manager.Comment("checking step \'return GetFileVolumSize/[out 4096]\'");
            TestManagerHelpers.AssertAreEqual<long>(this.Manager, 4096, temp3, "openFileVolumeSize of GetFileVolumSize, state S9");
            this.Manager.Comment("reaching state \'S10\'");
            long temp4;
            Microsoft.Protocols.TestSuites.FileSharing.FSA.Adapter.MessageStatus temp5;
            this.Manager.Comment("executing step \'call WriteFile(2,1,out _)\'");
            temp5 = this.IFSAAdapterInstance.WriteFile(2, 1, out temp4);
            this.Manager.Checkpoint("MS-FSA_R712");
            this.Manager.Checkpoint(@"[In Server Requests a Write]Pseudocode for the operation is as follows: 
                        If Open.Mode.FILE_NO_INTERMEDIATE_BUFFERING is TRUE and (ByteOffset >= 0), the operation MUST be failed with STATUS_INVALID_PARAMETER 
                        under any of the following conditions:If (ByteOffset % Open.File.Volume.SectorSize) is not zero.");
            this.Manager.Comment("reaching state \'S11\'");
            this.Manager.Comment("checking step \'return WriteFile/[out 0]:INVALID_PARAMETER\'");
            TestManagerHelpers.AssertAreEqual<long>(this.Manager, 0, temp4, "bytesWritten of WriteFile, state S11");
            TestManagerHelpers.AssertAreEqual<Microsoft.Protocols.TestSuites.FileSharing.FSA.Adapter.MessageStatus>(this.Manager, Microsoft.Protocols.TestSuites.FileSharing.FSA.Adapter.MessageStatus.INVALID_PARAMETER, temp5, "return of WriteFile, state S11");
            this.Manager.Comment("reaching state \'S12\'");
            this.Manager.EndTest();
        }
        #endregion
    }
}