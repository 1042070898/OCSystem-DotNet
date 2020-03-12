﻿#nullable enable

using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;

namespace OnlyChain.Core {
    internal static class MerklePatriciaTreeSupport {
        public static readonly NotSupportedException NotSupportedException = new NotSupportedException();

        public interface IBlock { }

        [StructLayout(LayoutKind.Sequential, Size = 1)] public struct Block1 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 2)] public struct Block2 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 3)] public struct Block3 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 4)] public struct Block4 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 5)] public struct Block5 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 6)] public struct Block6 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 7)] public struct Block7 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 8)] public struct Block8 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 9)] public struct Block9 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 10)] public struct Block10 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 11)] public struct Block11 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 12)] public struct Block12 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 13)] public struct Block13 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 14)] public struct Block14 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 15)] public struct Block15 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 16)] public struct Block16 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 17)] public struct Block17 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 18)] public struct Block18 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 19)] public struct Block19 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 20)] public struct Block20 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 21)] public struct Block21 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 22)] public struct Block22 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 23)] public struct Block23 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 24)] public struct Block24 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 25)] public struct Block25 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 26)] public struct Block26 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 27)] public struct Block27 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 28)] public struct Block28 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 29)] public struct Block29 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 30)] public struct Block30 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 31)] public struct Block31 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 32)] public struct Block32 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 33)] public struct Block33 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 34)] public struct Block34 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 35)] public struct Block35 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 36)] public struct Block36 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 37)] public struct Block37 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 38)] public struct Block38 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 39)] public struct Block39 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 40)] public struct Block40 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 41)] public struct Block41 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 42)] public struct Block42 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 43)] public struct Block43 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 44)] public struct Block44 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 45)] public struct Block45 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 46)] public struct Block46 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 47)] public struct Block47 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 48)] public struct Block48 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 49)] public struct Block49 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 50)] public struct Block50 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 51)] public struct Block51 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 52)] public struct Block52 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 53)] public struct Block53 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 54)] public struct Block54 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 55)] public struct Block55 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 56)] public struct Block56 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 57)] public struct Block57 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 58)] public struct Block58 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 59)] public struct Block59 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 60)] public struct Block60 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 61)] public struct Block61 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 62)] public struct Block62 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 63)] public struct Block63 : IBlock { }
        [StructLayout(LayoutKind.Sequential, Size = 64)] public struct Block64 : IBlock { }

        public interface ISoleReadOnlyList<T> : IList<T>, IReadOnlyList<T>, IEnumerator<T> {
            bool Got { get; set; }

            int ICollection<T>.Count => 1;
            bool ICollection<T>.IsReadOnly => true;
            void ICollection<T>.Add(T item) => throw NotSupportedException;
            bool ICollection<T>.Remove(T item) => throw NotSupportedException;
            void ICollection<T>.Clear() => throw NotSupportedException;
            bool ICollection<T>.Contains(T item) => EqualityComparer<T>.Default.Equals(Current, item);
            void ICollection<T>.CopyTo(T[] array, int arrayIndex) {
                if ((uint)arrayIndex >= (uint)array.Length) throw new ArgumentOutOfRangeException(nameof(arrayIndex));
                array[arrayIndex] = Current;
            }

            int IReadOnlyCollection<T>.Count => 1;

            T IReadOnlyList<T>.this[int index] => index == 0 ? Current : throw new ArgumentOutOfRangeException(nameof(index));

            T IList<T>.this[int index] {
                get => index == 0 ? Current : throw new ArgumentOutOfRangeException(nameof(index));
                set => throw NotSupportedException;
            }
            int IList<T>.IndexOf(T item) => EqualityComparer<T>.Default.Equals(Current, item) ? 0 : -1;
            void IList<T>.RemoveAt(int index) => throw NotSupportedException;
            void IList<T>.Insert(int index, T item) => throw NotSupportedException;

            object? IEnumerator.Current => Current;
            IEnumerator IEnumerable.GetEnumerator() => this;
            void IEnumerator.Reset() => throw NotSupportedException;
            bool IEnumerator.MoveNext() => Got ? false : (Got = true);

            IEnumerator<T> IEnumerable<T>.GetEnumerator() => this;

            void IDisposable.Dispose() => Got = false;
        }

        public sealed class SoleList<T> : ISoleReadOnlyList<T> {
            bool ISoleReadOnlyList<T>.Got { get; set; } = false;
            public T Current { get; }

            public SoleList(T value) => Current = value;
        }
    }

    unsafe partial class MerklePatriciaTree<TKey, TValue, THash> {
        internal static class Support {
            delegate Node CreateNodeHandler(int generation, byte* key, Node value);

            static readonly CreateNodeHandler[] createNodeHandlers = {
                (generation, key, child) => child,
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block1>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block2>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block3>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block4>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block5>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block6>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block7>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block8>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block9>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block10>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block11>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block12>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block13>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block14>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block15>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block16>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block17>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block18>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block19>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block20>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block21>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block22>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block23>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block24>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block25>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block26>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block27>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block28>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block29>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block30>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block31>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block32>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block33>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block34>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block35>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block36>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block37>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block38>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block39>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block40>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block41>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block42>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block43>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block44>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block45>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block46>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block47>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block48>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block49>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block50>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block51>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block52>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block53>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block54>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block55>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block56>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block57>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block58>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block59>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block60>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block61>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block62>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block63>(generation, key, child),
                (generation, key, child) => new LongPathNode<MerklePatriciaTreeSupport.Block64>(generation, key, child),
            };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            static ValueNode CreateValue(ref AddArgs args) {
                args.Result = true;
                args.Update = false;
                return new ValueNode(args.Generation, args.HashAlgorithm.ComputeHash(args.Value), args.Value);
            }

            public ref struct AddArgs {
                public TValue Value;
                public IHashAlgorithm<TValue, THash> HashAlgorithm;
                public int Generation;
                public bool Result;
                public bool Update;
            }

            public ref struct RemoveArgs {
                public TValue Value;
                public IHashAlgorithm<TValue, THash> HashAlgorithm;
                public int Generation;
                public bool Result;
                public bool NeedCompareValue;
                public bool NeedSetValue;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static Node CreateLongPathNode(int generation, byte* key, int length, Node child) => createNodeHandlers[length](generation, key, child);


            public abstract class Node {
                public readonly int Generation;

                public THash Hash;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public Node(int generation, THash hash) {
                    Generation = generation;
                    Hash = hash;
                }

                public Node(int generation) {
                    Generation = generation;
                }

                public abstract Node Add(ref AddArgs args, byte* key, int length);
                public abstract IEnumerable<KeyValuePair<TKey, TValue>> Enumerate(int index, byte[] key);
                public abstract Node? Remove(ref RemoveArgs args, byte* key);
                public abstract bool TryGetValue(byte* key, [MaybeNullWhen(false)] out TValue value);
                public virtual Node PrefixConcat<TBlock>(LongPathNode<TBlock> parent) where TBlock : unmanaged, MerklePatriciaTreeSupport.IBlock => parent;
            }


            public sealed class EmptyNode : Node {
                private Node? child;

                public EmptyNode(int generation, THash hash) : base(generation, hash) => child = null;

                private EmptyNode(int generation, Node child) : base(generation, child.Hash) => this.child = child;

                public override Node Add(ref AddArgs args, byte* key, int length) {
                    Node newChild;
                    if (child is null) {
                        newChild = CreateLongPathNode(args.Generation, key, length, CreateValue(ref args));
                    } else {
                        newChild = child.Add(ref args, key, length);
                    }

                    if (args.Result) {
                        if (Generation == args.Generation) {
                            child = newChild;
                        } else if (child != newChild) {
                            return new EmptyNode(args.Generation, newChild);
                        }
                    }
                    return this;
                }

                public override IEnumerable<KeyValuePair<TKey, TValue>> Enumerate(int index, byte[] key) {
                    return child is null ? Enumerable.Empty<KeyValuePair<TKey, TValue>>() : child.Enumerate(index, key);
                }

                public override Node? Remove(ref RemoveArgs args, byte* key) {
                    if (child != null) {
                        Node? newChild = child.Remove(ref args, key);
                        if (args.Result) {
                            if (Generation == args.Generation) {
                                child = newChild;
                            } else if (child != newChild) {
                                if (newChild != null) {
                                    return new EmptyNode(args.Generation, newChild);
                                } else {
                                    return new EmptyNode(args.Generation, args.HashAlgorithm.ComputeHash(ReadOnlySpan<THash>.Empty));
                                }
                            }
                        }
                    }
                    return this;
                }

                public override bool TryGetValue(byte* key, out TValue value) {
                    if (child is null) {
                        value = default!;
                        return false;
                    }
                    return child.TryGetValue(key, out value);
                }

                public EmptyNode Clear(ref RemoveArgs args) {
                    if (child != null) {
                        if (Generation == args.Generation) {
                            child = null;
                        } else {
                            return new EmptyNode(args.Generation, args.HashAlgorithm.ComputeHash(ReadOnlySpan<THash>.Empty));
                        }
                    }
                    return this;
                }
            }

            public sealed class PrefixMapNode : Node {
                [StructLayout(LayoutKind.Sequential)]
                struct Children {
                    [SuppressMessage("样式", "IDE0044:添加只读修饰符", Justification = "<挂起>")]
                    public Node? child_0,
                                 child_1,
                                 child_2,
                                 child_3,
                                 child_4,
                                 child_5,
                                 child_6,
                                 child_7,
                                 child_8,
                                 child_9,
                                 child_a,
                                 child_b,
                                 child_c,
                                 child_d,
                                 child_e,
                                 child_f;
                }

                private Children children;


                internal ref Node? this[int i] => ref Unsafe.Add(ref children.child_0, i);

                public PrefixMapNode(int generation) : base(generation) { }

                private PrefixMapNode(int generation, PrefixMapNode other) : base(generation) {
                    MemoryMarshal.CreateReadOnlySpan(ref other.children.child_0, 16).CopyTo(MemoryMarshal.CreateSpan(ref children.child_0, 16));
                }

                public override bool TryGetValue(byte* key, out TValue value) {
                    if (this[*key] is Node child) {
                        return child.TryGetValue(key + 1, out value);
                    }
                    value = default!;
                    return false;
                }

                public override Node Add(ref AddArgs args, byte* key, int length) {
                    Node? newChild;
                    if (this[*key] is Node child) {
                        newChild = child.Add(ref args, key + 1, length - 1);
                    } else {
                        newChild = CreateLongPathNode(args.Generation, key + 1, length - 1, CreateValue(ref args));
                    }

                    if (args.Result) {
                        if (Generation == args.Generation) {
                            this[*key] = newChild;
                        } else if (this[*key] != newChild) {
                            var clone = new PrefixMapNode(args.Generation, this);
                            clone[*key] = newChild;
                            return clone;
                        }
                    }
                    return this;
                }

                public override IEnumerable<KeyValuePair<TKey, TValue>> Enumerate(int index, byte[] key) {
                    for (int i = 0; i < 16; i++) {
                        if (this[i] is Node child) {
                            key[index] = (byte)i;
                            foreach (var kv in child.Enumerate(index + 1, key)) yield return kv;
                        }
                    }
                }

                public override Node? Remove(ref RemoveArgs args, byte* key) {
                    if (this[*key] is Node child) {
                        Node? newChild = child.Remove(ref args, key + 1);
                        if (!args.Result) return this;
                        if (newChild != null) {
                            if (Generation == args.Generation) {
                                this[*key] = newChild;
                                return this;
                            } else if (this[*key] != newChild) {
                                var clone = new PrefixMapNode(args.Generation, this);
                                clone[*key] = newChild;
                                return clone;
                            }
                        }
                    } else {
                        return this;
                    }

                    // newChild == null
                    byte p1 = 0xff, p2 = 0xff;
                    for (int i = 0; i < 16; i++) {
                        if (this[i] is Node) {
                            p2 = p1;
                            p1 = (byte)i;
                        }
                    }

                    if (p2 != 0xff) { // 移除后的子节点数量 >= 2
                        if (Generation == args.Generation) {
                            this[*key] = null;
                            return this;
                        } else {
                            var clone = new PrefixMapNode(args.Generation, this);
                            clone[*key] = null;
                            return clone;
                        }
                    }

                    var result = new LongPathNode<MerklePatriciaTreeSupport.Block1>(args.Generation, &p1, this[p1]!);
                    return this[p1]!.PrefixConcat(result);
                }

                public override string ToString() {
                    var list = new List<char>(16);
                    for (int i = 0; i < 16; i++) {
                        if (this[i] is Node) list.Add("0123456789abcdef"[i]);
                    }
                    return $"[{string.Join(",", list)}],count={list.Count}";
                }
            }

            public sealed class BinaryBranchNode : Node {
                private readonly byte prefix1, prefix2;
                private Node child1, child2;

                public BinaryBranchNode(int generation, byte prefix1, byte prefix2, Node child1, Node child2) : base(generation) {
                    if (prefix1 < prefix2) {
                        this.prefix1 = prefix1;
                        this.prefix2 = prefix2;
                        this.child1 = child1;
                        this.child2 = child2;
                    } else {
                        this.prefix1 = prefix2;
                        this.prefix2 = prefix1;
                        this.child1 = child2;
                        this.child2 = child1;
                    }
                }

                public override bool TryGetValue(byte* key, out TValue value) {
                    if (*key == prefix1) return child1.TryGetValue(key + 1, out value);
                    if (*key == prefix2) return child2.TryGetValue(key + 1, out value);
                    value = default!;
                    return false;
                }

                public override Node Add(ref AddArgs args, byte* key, int length) {
                    if (*key == prefix1) {
                        Node? newChild = child1.Add(ref args, key + 1, length - 1);
                        if (args.Result) {
                            if (Generation == args.Generation) {
                                child1 = newChild;
                            } else if (child1 != newChild) {
                                return new BinaryBranchNode(args.Generation, prefix1, prefix2, newChild, child2);
                            }
                        }
                        return this;
                    }
                    if (*key == prefix2) {
                        Node? newChild = child2.Add(ref args, key + 1, length - 1);
                        if (args.Result) {
                            if (Generation == args.Generation) {
                                child2 = newChild;
                            } else if (child2 != newChild) {
                                return new BinaryBranchNode(args.Generation, prefix1, prefix2, child1, newChild);
                            }
                        }
                        return this;
                    }

                    var result = new PrefixMapNode(args.Generation);
                    result[prefix1] = child1;
                    result[prefix2] = child2;
                    result[*key] = CreateLongPathNode(args.Generation, key + 1, length - 1, CreateValue(ref args));
                    return result;
                }

                public override IEnumerable<KeyValuePair<TKey, TValue>> Enumerate(int index, byte[] key) {
                    if (prefix1 < prefix2) {
                        key[index] = prefix1;
                        foreach (var kv in child1.Enumerate(index + 1, key)) yield return kv;
                        key[index] = prefix2;
                        foreach (var kv in child2.Enumerate(index + 1, key)) yield return kv;
                    } else {
                        key[index] = prefix2;
                        foreach (var kv in child2.Enumerate(index + 1, key)) yield return kv;
                        key[index] = prefix1;
                        foreach (var kv in child1.Enumerate(index + 1, key)) yield return kv;
                    }
                }

                public override Node? Remove(ref RemoveArgs args, byte* key) {
                    byte thisPrefix = *key, otherPrefix;
                    ref var child = ref Unsafe.AsRef<Node>(null);
                    Node otherChild;
                    if (prefix1 == thisPrefix) {
                        otherPrefix = prefix2;
                        child = ref child1;
                        otherChild = child2;
                    } else if (prefix2 == thisPrefix) {
                        otherPrefix = prefix1;
                        child = ref child2;
                        otherChild = child1;
                    } else {
                        return this;
                    }

                    var newChild = child.Remove(ref args, key + 1);
                    if (!args.Result) return this;
                    if (newChild is Node) {
                        if (Generation == args.Generation) {
                            child = newChild;
                        } else if (child != newChild) {
                            return new BinaryBranchNode(args.Generation, thisPrefix, otherPrefix, newChild, otherChild);
                        }
                        return this;
                    }

                    var result = new LongPathNode<MerklePatriciaTreeSupport.Block1>(args.Generation, &otherPrefix, otherChild);
                    return otherChild.PrefixConcat(result);
                }

                public override string ToString() {
                    if (prefix1 < prefix2) {
                        return $"[{"0123456789abcdef"[prefix1]},{"0123456789abcdef"[prefix2]}]";
                    } else {
                        return $"[{"0123456789abcdef"[prefix2]},{"0123456789abcdef"[prefix1]}]";
                    }
                }
            }

            public sealed class LongPathNode<TBlock> : Node where TBlock : unmanaged, MerklePatriciaTreeSupport.IBlock {
                static readonly int BlockSize = sizeof(TBlock);

                private TBlock path;
                private Node child;

                public LongPathNode(int generation, byte* key, Node child) : base(generation) {
                    new ReadOnlySpan<byte>(key, sizeof(TBlock)).CopyTo(MemoryMarshal.CreateSpan(ref Unsafe.As<TBlock, byte>(ref path), sizeof(TBlock)));
                    this.child = child;
                }

                public override Node Add(ref AddArgs args, byte* key, int length) {
                    fixed (TBlock* path = &this.path) {
                        int commonPrefix = 0;
                        for (; commonPrefix < sizeof(TBlock); commonPrefix++) {
                            if (((byte*)path)[commonPrefix] != key[commonPrefix]) goto Split;
                        }

                        Node newChild = child.Add(ref args, key + sizeof(TBlock), length - sizeof(TBlock));
                        if (args.Result) {
                            if (Generation == args.Generation) {
                                child = newChild;
                            } else if (child != newChild) {
                                return new LongPathNode<TBlock>(args.Generation, key, newChild);
                            }
                        }
                        return this;

                    Split:
                        var binaryNode = new BinaryBranchNode(
                            args.Generation,
                            ((byte*)path)[commonPrefix],
                            key[commonPrefix],
                            CreateLongPathNode(args.Generation, (byte*)path + (commonPrefix + 1), sizeof(TBlock) - (commonPrefix + 1), child),
                            CreateLongPathNode(args.Generation, key + (commonPrefix + 1), length - (commonPrefix + 1), CreateValue(ref args))
                        );
                        return CreateLongPathNode(args.Generation, key, commonPrefix, binaryNode);
                    }
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                void PathWriteTo(Span<byte> span) {
                    MemoryMarshal.CreateReadOnlySpan(ref Unsafe.As<TBlock, byte>(ref path), sizeof(TBlock)).CopyTo(span);
                }

                public override IEnumerable<KeyValuePair<TKey, TValue>> Enumerate(int index, byte[] key) {
                    PathWriteTo(key.AsSpan(index));
                    foreach (var kv in child.Enumerate(index + BlockSize, key)) yield return kv;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                private bool SequenceEqual(byte* key) {
                    return new ReadOnlySpan<byte>(key, sizeof(TBlock)).SequenceEqual(MemoryMarshal.CreateReadOnlySpan(ref Unsafe.As<TBlock, byte>(ref path), sizeof(TBlock)));
                }

                public override bool TryGetValue(byte* key, out TValue value) {
                    if (SequenceEqual(key)) {
                        return child.TryGetValue(key + sizeof(TBlock), out value);
                    }
                    value = default!;
                    return false;
                }

                public override Node? Remove(ref RemoveArgs args, byte* key) {
                    if (SequenceEqual(key)) {
                        var newChild = child.Remove(ref args, key + sizeof(TBlock));
                        if (args.Result) {
                            if (newChild is null) return null;

                            if (Generation == args.Generation) {
                                child = newChild;
                            } else if (child != newChild) {
                                return new LongPathNode<TBlock>(args.Generation, key, newChild);
                            }
                        }
                    }
                    return this;
                }

                public override Node PrefixConcat<TPrefixBlock>(LongPathNode<TPrefixBlock> parent) {
                    var path = stackalloc byte[sizeof(TPrefixBlock) + sizeof(TBlock)];
                    parent.PathWriteTo(new Span<byte>(path, sizeof(TPrefixBlock)));
                    PathWriteTo(new Span<byte>(path + sizeof(TPrefixBlock), sizeof(TBlock)));
                    return CreateLongPathNode(parent.Generation, path, sizeof(TPrefixBlock) + sizeof(TBlock), child);
                }

                public override string ToString() {
                    var chars = stackalloc char[sizeof(TBlock)];
                    for (int i = 0; i < sizeof(TBlock); i++) {
                        chars[i] = "0123456789abcdef"[Unsafe.Add(ref Unsafe.As<TBlock, byte>(ref path), i)];
                    }
                    return new string(chars, 0, sizeof(TBlock)) + ",length=" + sizeof(TBlock);
                }
            }

            public sealed class ValueNode : Node {
                private TValue value;

                public ValueNode(int generation, THash hash, TValue value) : base(generation, hash) => this.value = value;

                public override Node Add(ref AddArgs args, byte* key, int length) {
                    if (args.Update) {
                        args.Result = true;
                        if (Generation == args.Generation) {
                            value = args.Value;
                            Hash = args.HashAlgorithm.ComputeHash(args.Value);
                        } else {
                            return new ValueNode(args.Generation, args.HashAlgorithm.ComputeHash(args.Value), args.Value);
                        }
                    }
                    return this;
                }

                public override bool TryGetValue(byte* key, out TValue value) {
                    value = this.value;
                    return true;
                }

                public override IEnumerable<KeyValuePair<TKey, TValue>> Enumerate(int index, byte[] key) {
                    TKey tempKey = default;
                    fixed (byte* buffer = key) {
                        BufferToKey(buffer, &tempKey);
                    }
                    return new MerklePatriciaTreeSupport.SoleList<KeyValuePair<TKey, TValue>>(new KeyValuePair<TKey, TValue>(tempKey, value));
                }

                public override Node? Remove(ref RemoveArgs args, byte* key) {
                    if (args.NeedCompareValue && !EqualityComparer<TValue>.Default.Equals(value, args.Value)) {
                        return this;
                    }
                    if (args.NeedSetValue) args.Value = value;
                    args.Result = true;
                    return null;
                }

                public override string? ToString() => value?.ToString();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            public static void KeyToBuffer(TKey* key, byte* buffer) {
                for (int i = 0; i < sizeof(TKey); i++) {
                    buffer[2 * i] = (byte)(((byte*)key)[i] >> 4);
                    buffer[2 * i + 1] = (byte)(((byte*)key)[i] & 15);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            public static void BufferToKey(byte* buffer, TKey* key) {
                for (int i = 0; i < sizeof(TKey); i++) {
                    ((byte*)key)[i] = (byte)((buffer[2 * i] << 4) | buffer[2 * i + 1]);
                }
            }
        }
    }

    unsafe public partial class MerklePatriciaTree<TKey, TValue, THash> : IDictionary<TKey, TValue>, IReadOnlyDictionary<TKey, TValue> where TKey : unmanaged where TValue : notnull where THash : unmanaged {
        private Support.EmptyNode root;
        private readonly IHashAlgorithm<TValue, THash> hashAlgorithm;

        public MerklePatriciaTree(int generation, IHashAlgorithm<TValue, THash> hashAlgorithm) {
            Generation = generation;
            this.hashAlgorithm = hashAlgorithm ?? throw new ArgumentNullException(nameof(hashAlgorithm));
            root = new Support.EmptyNode(generation, hashAlgorithm.ComputeHash(ReadOnlySpan<THash>.Empty));
            Count = 0;
        }

        public MerklePatriciaTree(MerklePatriciaTree<TKey, TValue, THash> parentTree, int generation) {
            if (generation <= parentTree.Generation) throw new ArgumentOutOfRangeException(nameof(generation), "MPT代数太低");

            Generation = generation;
            root = parentTree.root;
            hashAlgorithm = parentTree.hashAlgorithm;
            Count = parentTree.Count;
        }

        public MerklePatriciaTree<TKey, TValue, THash> NewNext() => new MerklePatriciaTree<TKey, TValue, THash>(this, Generation + 1);

        public int Generation { get; }

        public TValue this[TKey key] {
            get {
                if (TryGetValue(key, out var value)) return value;
                throw new KeyNotFoundException($"键值'{key}'不存在");
            }
            set {
                AddOrUpdate(key, value, true);
            }
        }

        public ICollection<TKey> Keys => new KeyEnumerator(this);

        public ICollection<TValue> Values => new ValueEnumerator(this);

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => Keys;

        IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => Values;

        private bool AddOrUpdate(TKey key, TValue value, bool update) {
            var keyBuffer = stackalloc byte[sizeof(TKey) * 2];
            Support.KeyToBuffer(&key, keyBuffer);

            var args = new Support.AddArgs {
                HashAlgorithm = hashAlgorithm,
                Generation = Generation,
                Value = value,
                Update = update,
            };
            root = (Support.EmptyNode)root.Add(ref args, keyBuffer, sizeof(TKey) * 2);
            if (args.Result & !args.Update) {
                Count++;
            }
            return args.Result;
        }

        public void Add(TKey key, TValue value) {
            if (!AddOrUpdate(key, value, false)) {
                throw new ArgumentException($"键值'{key}'已存在", nameof(key));
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item) {
            Add(item.Key, item.Value);
        }

        public bool TryAdd(TKey key, TValue value) => AddOrUpdate(key, value, false);

        public void Clear() {
            if (Count != 0) {
                var args = new Support.RemoveArgs {
                    HashAlgorithm = hashAlgorithm,
                    Generation = Generation,
                };
                root = root.Clear(ref args);
                Count = 0;
            }
        }

        public bool Contains(KeyValuePair<TKey, TValue> item) {
            if (TryGetValue(item.Key, out var value)) {
                return EqualityComparer<TValue>.Default.Equals(value, item.Value);
            }
            return false;
        }

        public bool ContainsKey(TKey key) => TryGetValue(key, out _);

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) {
            if (arrayIndex + Count < array.Length) throw new ArgumentOutOfRangeException();
            int i = 0;
            foreach (var kv in this) {
                array[arrayIndex + i++] = kv;
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() {
            if (Count == 0) yield break;

            var buffer = ArrayRent();
            try {
                foreach (var kv in root.Enumerate(0, buffer)) yield return kv;
            } finally {
                ArrayPool<byte>.Shared.Return(buffer);
            }

            static byte[] ArrayRent() => ArrayPool<byte>.Shared.Rent(sizeof(TKey) * 2);
        }

        public bool Remove(TKey key) {
            if (Count == 0) return false;

            var keyBuffer = stackalloc byte[sizeof(TKey) * 2];
            Support.KeyToBuffer(&key, keyBuffer);

            var args = new Support.RemoveArgs {
                HashAlgorithm = hashAlgorithm,
                Generation = Generation,
            };
            root = (Support.EmptyNode)root.Remove(ref args, keyBuffer)!;
            if (args.Result) {
                Count--;
                return true;
            }
            return false;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item) {
            if (Count == 0) return false;

            TKey key = item.Key;
            var keyBuffer = stackalloc byte[sizeof(TKey) * 2];
            Support.KeyToBuffer(&key, keyBuffer);

            var args = new Support.RemoveArgs {
                HashAlgorithm = hashAlgorithm,
                Generation = Generation,
                Value = item.Value,
                NeedCompareValue = true,
            };
            root = (Support.EmptyNode)root.Remove(ref args, keyBuffer)!;
            if (args.Result) {
                Count--;
                return true;
            }
            return false;
        }

        public bool Remove(TKey key, out TValue value) {
            if (Count == 0) {
                value = default!;
                return false;
            }

            var keyBuffer = stackalloc byte[sizeof(TKey) * 2];
            Support.KeyToBuffer(&key, keyBuffer);

            var args = new Support.RemoveArgs {
                HashAlgorithm = hashAlgorithm,
                Generation = Generation,
                NeedSetValue = true,
            };
            root = (Support.EmptyNode)root.Remove(ref args, keyBuffer)!;
            if (args.Result) {
                Count--;
                value = args.Value;
                return true;
            }
            value = default!;
            return false;
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value) {
            if (Count == 0) {
                value = default!;
                return false;
            }

            var keyBuffer = stackalloc byte[sizeof(TKey) * 2];
            Support.KeyToBuffer(&key, keyBuffer);
            return root.TryGetValue(keyBuffer, out value);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        sealed class KeyEnumerator : ICollection<TKey> {
            readonly IDictionary<TKey, TValue> source;

            public KeyEnumerator(IDictionary<TKey, TValue> source) {
                this.source = source;
            }

            public int Count => source.Count;

            public bool IsReadOnly => true;

            public void Add(TKey item) {
                throw MerklePatriciaTreeSupport.NotSupportedException;
            }

            public void Clear() {
                throw MerklePatriciaTreeSupport.NotSupportedException;
            }

            public bool Contains(TKey item) {
                return source.ContainsKey(item);
            }

            public void CopyTo(TKey[] array, int arrayIndex) {
                if (arrayIndex < 0 || arrayIndex + Count > array.Length) throw new ArgumentOutOfRangeException();
                int i = 0;
                foreach (var key in this) {
                    array[arrayIndex + i++] = key;
                }
            }

            public IEnumerator<TKey> GetEnumerator() => source.Select(kv => kv.Key).GetEnumerator();

            public bool Remove(TKey item) {
                throw MerklePatriciaTreeSupport.NotSupportedException;
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        sealed class ValueEnumerator : ICollection<TValue> {
            readonly IDictionary<TKey, TValue> source;

            public ValueEnumerator(IDictionary<TKey, TValue> source) {
                this.source = source;
            }

            public int Count => source.Count;

            public bool IsReadOnly => true;

            public void Add(TValue item) {
                throw MerklePatriciaTreeSupport.NotSupportedException;
            }

            public void Clear() {
                throw MerklePatriciaTreeSupport.NotSupportedException;
            }

            public bool Contains(TValue item) => source.Select(kv => kv.Value).Contains(item);

            public void CopyTo(TValue[] array, int arrayIndex) {
                if (arrayIndex < 0 || arrayIndex + Count > array.Length) throw new ArgumentOutOfRangeException();
                int i = 0;
                foreach (var key in this) {
                    array[arrayIndex + i++] = key;
                }
            }

            public IEnumerator<TValue> GetEnumerator() => source.Select(kv => kv.Value).GetEnumerator();

            public bool Remove(TValue item) {
                throw MerklePatriciaTreeSupport.NotSupportedException;
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
