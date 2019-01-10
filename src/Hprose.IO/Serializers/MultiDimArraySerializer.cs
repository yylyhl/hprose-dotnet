﻿/**********************************************************\
|                                                          |
|                          hprose                          |
|                                                          |
| Official WebSite: http://www.hprose.com/                 |
|                   http://www.hprose.org/                 |
|                                                          |
\**********************************************************/
/**********************************************************\
 *                                                        *
 * MultiDimArraySerializer.cs                             *
 *                                                        *
 * MultiDimArraySerializer class for C#.                  *
 *                                                        *
 * LastModified: Jan 11, 2019                             *
 * Author: Ma Bingyao <andot@hprose.com>                  *
 *                                                        *
\**********************************************************/

using System;

namespace Hprose.IO.Serializers {
    using static Tags;

    class MultiDimArraySerializer<T> : ReferenceSerializer<T> {
        public override void Write(Writer writer, T obj) {
            base.Write(writer, obj);
            Array array = (Array)(object)obj;
            int rank = array.Rank;
            int i;
            int[,] des = new int[rank, 2];
            int[] loc = new int[rank];
            int[] len = new int[rank];
            int maxrank = rank - 1;
            for (i = 0; i < rank; ++i) {
                des[i, 0] = array.GetLowerBound(i);
                des[i, 1] = array.GetUpperBound(i);
                loc[i] = des[i, 0];
                len[i] = array.GetLength(i);
            }
            var stream = writer.Stream;
            stream.WriteByte(TagList);
            if (len[0] > 0) ValueWriter.WriteInt(stream, len[0]);
            stream.WriteByte(TagOpenbrace);
            var serializer = Serializer.Instance;
            while (loc[0] <= des[0, 1]) {
                int n = 0;
                for (i = maxrank; i > 0; i--) {
                    if (loc[i] == des[i, 0]) {
                        n++;
                    }
                    else {
                        break;
                    }
                }
                for (i = rank - n; i < rank; ++i) {
                    writer.SetReference(new object());
                    stream.WriteByte(TagList);
                    if (len[i] > 0) ValueWriter.WriteInt(stream, len[i]);
                    stream.WriteByte(TagOpenbrace);
                }
                for (loc[maxrank] = des[maxrank, 0];
                     loc[maxrank] <= des[maxrank, 1];
                     loc[maxrank]++) {
                    serializer.Serialize(writer, array.GetValue(loc));
                }
                for (i = maxrank; i > 0; i--) {
                    if (loc[i] > des[i, 1]) {
                        loc[i] = des[i, 0];
                        loc[i - 1]++;
                        stream.WriteByte(TagClosebrace);
                    }
                }
            }
            stream.WriteByte(TagClosebrace);
        }
    }
}
