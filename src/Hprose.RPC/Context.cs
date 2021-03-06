﻿/*--------------------------------------------------------*\
|                                                          |
|                          hprose                          |
|                                                          |
| Official WebSite: https://hprose.com                     |
|                                                          |
|  Context.cs                                              |
|                                                          |
|  Context class for C#.                                   |
|                                                          |
|  LastModified: Feb 18, 2019                              |
|  Author: Ma Bingyao <andot@hprose.com>                   |
|                                                          |
\*________________________________________________________*/

using System;
using System.Collections.Generic;

namespace Hprose.RPC {
    public class Context : ICloneable {
        public IDictionary<string, object> Items { get; private set; } = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);
        public object this[string name] {
            get => Items[name];
            set => Items[name] = value;
        }
        protected static void Copy(IDictionary<string, object> src, IDictionary<string, object> dist) {
            if (src != null) {
                foreach (var p in src) dist[p.Key] = p.Value;
            }
        }
        public bool Contains(string name) {
            return Items.ContainsKey(name);
        }
        public virtual object Clone() {
            var context = MemberwiseClone() as Context;
            context.Items = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);
            Copy(Items, context.Items);
            return context;
        }
    }
}