﻿#nullable enable
namespace UnityEditor.UIElements {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using UnityEditor;
    using UnityEngine;

    public class PugPostprocessor : AssetPostprocessor {

        private const string CompilePugScript = @"
            ""use strict"";
            const Process = require('node:process');
            const FS = require('fs');
            const Path = require('path');
            const Pug = require( require.resolve('pug', { paths: [ Path.join(process.env.APPDATA, '/npm/node_modules') ] } ) );

            const src = Process.argv[1];
            const dist = Process.argv[2];
            const source = FS.readFileSync(src, 'utf8');
            const options = {
                doctype: 'xml',
                pretty: true
            };

            Pug.render(source, options, onComplete);

            // onCallback
            function onComplete(error, result) {
                if (error) {
                    console.error(error);
                    FS.writeFile(dist, '', onError);
                } else {
                    FS.writeFile(dist, result.replaceAll('::', '.'), onError);
                }
            }
            function onError(error) {
                if (error) {
                    console.error(error);
                }
            }";

        // OnPostprocessAllAssets
        public static void OnPostprocessAllAssets(string[] imported, string[] deleted, string[] moved, string[] movedFrom) {
            foreach (var imported_ in imported) {
                OnAssetImported( imported_ );
            }
            foreach (var deleted_ in deleted) {
                OnAssetDeleted( deleted_ );
            }
            foreach (var (moved_, movedFrom_) in moved.Zip( movedFrom, (a, b) => (a, b) )) {
                OnAssetMoved( moved_, movedFrom_ );
            }
        }
        private static void OnAssetImported(string path) {
            if (IsPug( path ) && IsSupported( path )) {
                CompilePug( path, Path.ChangeExtension( path, ".uxml" ) );
                AssetDatabase.ImportAsset( Path.ChangeExtension( path, ".uxml" ) );
            }
        }
        private static void OnAssetDeleted(string path) {
            if (IsPug( path )) {
                AssetDatabase.DeleteAsset( Path.ChangeExtension( path, ".uxml" ) );
            }
        }
        private static void OnAssetMoved(string newPath, string oldPath) {
            if (IsPug( oldPath )) {
                AssetDatabase.MoveAsset( Path.ChangeExtension( oldPath, ".uxml" ), Path.ChangeExtension( newPath, ".uxml" ) );
            }
        }

        // Helpers
        private static void CompilePug(string src, string dist) {
            NodeJS.EvaluateJavaScript( CompilePugScript, src, dist );
        }
        private static bool IsPug(string path) {
            return Path.GetExtension( path ) == ".pug";
        }
        private static bool IsSupported(string path) {
            return !Path.GetFileName( path ).StartsWith( "_" );
        }

    }
}