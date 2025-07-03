// Copyright (c) 2019, Advanced Realtime Tracking GmbH
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
//
// 1. Redistributions of source code must retain the above copyright
//    notice, this list of conditions and the following disclaimer.
// 2. Redistributions in binary form must reproduce the above copyright
//    notice, this list of conditions and the following disclaimer in the
//    documentation and/or other materials provided with the distribution.
// 3. Neither the name of copyright holder nor the names of its contributors
//    may be used to endorse or promote products derived from this software
//    without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.



namespace UnrealBuildTool.Rules
{
    using System.IO;
    using System;

	public class DTrackPlugin : ModuleRules
	{   
		public DTrackPlugin(ReadOnlyTargetRules Target) : base(Target)
		{	
			bPrecompile = true;
			PrivatePCHHeaderFile = "Private/DTrackPluginPrivatePCH.h";
			PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;

			PrivateIncludePaths.AddRange(
				new string[] {
					"DTrackPlugin/Private",
					// ... add other private include paths required here ...
				}
				);
			

			BuildVersion Version;
			
			if ( BuildVersion.TryRead( BuildVersion.GetDefaultFileName(), out Version )  &&  Version.MajorVersion >= 5 ) 
			{
				PublicDependencyModuleNames.AddRange(
					new string[] {
						"Core",
						"CoreUObject",
						"Engine",
						"InputDevice",
						"LiveLinkInterface",
                        "LiveLinkAnimationCore",
                    }
                    );
			}
			else
			{
				PublicDependencyModuleNames.AddRange(
					new string[] {
						"Core",
						"CoreUObject",
						"Engine",
						"InputDevice",
						"LiveLinkInterface",
					}
					);
			}
			
			
			PrivateDependencyModuleNames.AddRange(
				new string[]
				{
                    "LiveLink",
                    "LiveLinkMovieScene",
                }
                );

			DynamicallyLoadedModuleNames.AddRange(
				new string[]
				{
				}
				);

		}

        private void Trace(string msg)
        {
            //Log.TraceError("Plugin + : " + msg);
        }
	}

}