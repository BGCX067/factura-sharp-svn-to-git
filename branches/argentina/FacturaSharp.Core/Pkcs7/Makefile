GC=gmcs
LDFLAGS=-target:library
CFLAGS=-define:PLATFORM_MONO

sources=FacturaSharp.Core.Pkcs7.cs
output=$(output_prefix)/FacturaSharp.Core.Pkcs7.dll

all: $(output)

$(output): FacturaSharp.Core.Pkcs7.cs
	$(GC) $(LDFLAGS) $(CFLAGS) -out:$(output) $(sources)

clean:
	rm -rf $(output) || test 0
