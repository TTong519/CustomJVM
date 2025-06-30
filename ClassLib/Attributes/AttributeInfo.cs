using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Attributes
{
    public enum AttributeType
    {
        ConstantValue = 0x0001,
        Code = 0x0002,
        StackMapTable = 0x0003,
        Exceptions = 0x0004,
        InnerClasses = 0x0005,
        EnclosingMethod = 0x0006,
        Synthetic = 0x0007,
        Signature = 0x0008,
        SourceFile = 0x0009,
        SourceDebugExtension = 0x000A,
        LineNumberTable = 0x000B,
        LocalVariableTable = 0x000C,
        LocalVariableTypeTable = 0x000D,
        Deprecated = 0x000E,
        RuntimeVisibleAnnotations = 0x000F,
        RuntimeInvisibleAnnotations = 0x0010,
        RuntimeVisibleParameterAnnotations = 0x0011,
        RuntimeInvisibleParameterAnnotations = 0x0012,
        AnnotationDefault = 0x0013,
        BootstrapMethods = 0x0014
    }

    public abstract class AttributeInfo
    {
        protected AttributeType attributeType;
        protected uint attributeLength;
        public AttributeInfo(uint attributeLength)
        {
            this.attributeLength = attributeLength;
        }
    }
}
