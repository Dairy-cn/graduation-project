// umfatl.h : Declaration of the Cumfatl

#ifndef __UMFATL_H_
#define __UMFATL_H_

#include "resource.h"       // main symbols
#include <objsafe.h>  
#include "atlctl.h"//声明安全接口的头文件

/////////////////////////////////////////////////////////////////////////////
// Cumfatl
class ATL_NO_VTABLE Cumfatl : 
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<Cumfatl, &CLSID_umfatl>,
	public IConnectionPointContainerImpl<Cumfatl>,
	public IDispatchImpl<Iumfatl, &IID_Iumfatl, &LIBID_ATLUMFLib>,
	public IObjectSafetyImpl<Cumfatl,INTERFACESAFE_FOR_UNTRUSTED_CALLER||INTERFACESAFE_FOR_UNTRUSTED_DATA>
{
public:
	Cumfatl()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_UMFATL)

DECLARE_PROTECT_FINAL_CONSTRUCT()

BEGIN_COM_MAP(Cumfatl)
	COM_INTERFACE_ENTRY(Iumfatl)
	COM_INTERFACE_ENTRY(IDispatch)
	COM_INTERFACE_ENTRY(IConnectionPointContainer)
	COM_INTERFACE_ENTRY(IObjectSafety)//安全接口
END_COM_MAP()
 

BEGIN_CONNECTION_POINT_MAP(Cumfatl)
END_CONNECTION_POINT_MAP()

// 加入到CATID_SafeForScripting 和 CATID_SafeForInitializing COM分组 //2010.11.5
BEGIN_CATEGORY_MAP(Cumfatl)
    IMPLEMENTED_CATEGORY(CATID_SafeForScripting)
    IMPLEMENTED_CATEGORY(CATID_SafeForInitializing)
END_CATEGORY_MAP()

// Iumfatl
public:
	STDMETHOD(FWCosPinReload)(/*[in]*/ short icdev, /*[in]*/BSTR pbNewPin, /*[in]*/BSTR pbReloadKey, /*[out,retval]*/int* result);
	STDMETHOD(FWCosPinUnlock)(/*[in]*/ short icdev, /*[in]*/BSTR pbPin,/*[in]*/BSTR pbUnlockKey, /*[out,retval]*/short* result);
	STDMETHOD(GetDevSN)(/*[in]*/ short icdev, /*[out,retval]*/ BSTR* devSN);

	STDMETHOD(GetIDCardSN)(/*[in]*/short icdev, /*[out,retval]*/BSTR* cardSN);
	STDMETHOD(FWCosCreateADF)(/*[in]*/short icdev, /*[in]*/long usDirFileID,/*[in]*/long  ulCreateSec,/*[in]*/long  ulDeleteSec,/*[in]*/BSTR pbDirName,/*[out,retval]*/short* result);
	STDMETHOD(FWCosGetBalance)(/*[in]*/short icdev, /*[out,retval]*/int* result);
	STDMETHOD(FWCosPurchase)(/*[in]*/short icdev, /*[in]*/short ucKeyID, /*[in]*/int value, /*[in]*/BSTR terminalID, /*[in]*/BSTR pbPurchaseKey,/*[out,retval]*/short* result);
	STDMETHOD(FWCosCredit)(/*[in]*/short icdev, /*[in]*/short ucKeyID, /*[in]*/int value, /*[in]*/BSTR terminalID, /*[in]*/BSTR pbCreditKey,/*[out,retval]*/short* result);
	STDMETHOD(FWCosUpdatePin)(/*[in]*/short icdev, /*[in]*/BSTR pbOldPin,/*[in]*/BSTR pbNewPin, /*[out,retval]*/short* result);
	STDMETHOD(FWCosAddKeyEx)(/*[in]*/short icdev, /*[in]*/short bKeyType, /*[in]*/short ucKeyID, /*[in]*/BSTR pbKeyValue, /*[in]*/short ucSecUpdate, /*[in]*/short ucNextSt, /*[in]*/short ucMaxCntError, /*[in]*/short cryptyType,/*[out,retval]*/short* result);
	STDMETHOD(FWCosAddKey)(/*[in]*/short icdev, /*[in]*/short bKeyType, /*[in]*/BSTR pbKeyValue, /*[out,retval]*/short* result);
	STDMETHOD(FWCosCreateKeyFile)(/*[in]*/short icdev, /*[in]*/short usDirFileID, /*[in]*/short usFileID, /*[in]*/short uFileLen,/*[in]*/long ulGenSec,/*[out,retval]*/short* result);
	STDMETHOD(FWCosReadRecord)(/*[in]*/short icdev, /*[in]*/short ucFRecord, /*[in]*/short bRecordFileID, /*[in]*/short bRecordNum, /*[in]*/short bRecordLen, /*[out,retval]*/BSTR* rdata);
	STDMETHOD(FWCosUpdateKey)(/*[in]*/short icdev, /*[in]*/BSTR pbOldKey,/*[in]*/BSTR pbNewKey, /*[in]*/long bKeyType, /*[out,retval]*/short* result);
	STDMETHOD(FWCosVerifyKey)(/*[in]*/short icdev, /*[in]*/BSTR pbKey, /*[in]*/short ulKeyType,/*[out, retval]*/short* result);
	STDMETHOD(FWCosUpdateRecord)(/*[in]*/short icdev, /*[in]*/short ucRecord, /*[in]*/short bRecordFileID,/*[in]*/short bRecordNum, /*[in]*/BSTR pbRecData,/*[in]*/short cryptyType, /*[in]*/ BSTR pProKey,/*[out,retval]*/short* result);
	STDMETHOD(FWCosAppendRecord)(/*[in]*/short icdev, /*[in]*/short bRecordFileID, /*[in]*/BSTR pbRecData, /*[in]*/short cryptyType, /*[in]*/BSTR pProKey, /*[out,retval]*/short* result);
	STDMETHOD(FWCosUpdateBinaryFile)(/*[in]*/short icdev, /*[in]*/short usFileID, /*[in]*/short usOffset,/*[in]*/BSTR pbBinData, /*[in]*/short cryptyType, /*[in]*/BSTR pProKey, /*[out,retval]*/short* result);
	STDMETHOD(FWCosReadBinaryFile)(/*[in]*/short icdev, /*[in]*/ short usFileID, /*[in]*/ short usOffset,/*[in]*/short  usReadLen,/*[in]*/short cryptyType, /*[in]*/BSTR pProKey, /*[out,retval]*/BSTR*  result);
	STDMETHOD(FWCosActiveDirectory)(/*[in]*/short icdev, /*[in]*/ short usDirFileID,/*[out,retval]*/short* result);
	STDMETHOD(FWCosCreateRecordFile)(/*[in]*/short icdev, /*[in]*/short usDirFileID,/*[in]*/short ucFRecord,/*[in]*/short usFileID,/*[in]*/short bRecordNum,/*[in]*/short bRecordLen,/*[in]*/short cryptyType, /*[in]*/long ulReadSec, /*[in]*/long ulUpdateSec,/*[in]*/long ulDeleteSec,/*[out, retval]*/short* result );
	STDMETHOD(FWCosCreateBinaryFile)(/*[in]*/short icdev, /*[in]*/short usDirFileID,/*[in]*/short usFileID,/*[in]*/short usFileLen,/*[in]*/short cryptyType,/*[in]*/long ulReadSec,  /*[in]*/long ulUpdateSec, /*[in]*/long ulDeleteSec,/*[out,retval]*/short* result);
	STDMETHOD(FWCosSelectDirectory)(/*[in]*/short icdev, /*[in]*/short usDirID, /*[out,retval]*/short* result);
	STDMETHOD(FWCosCreateDirectory)(/*[in]*/short icdev, /*[in]*/ short usDirFileID,/*[in]*/short usDirSize, /*[in]*/long ulCreateSec ,/*[in]*/long ulDeleteSec,/*[out,retval]*/ short* result);
	STDMETHOD(FWCosDeleteFileSys)(/*[in]*/short icdev, /*[out,retval]*/ short* result);
	STDMETHOD(FWCosSelecteApp)(/*[in]*/ short icdev, /*[out,retval]*/ short* result);
	STDMETHOD(FWCosCreateMainApp)(/*[in]*/ short icdev, /*[out, retval]*/ short* result);
	STDMETHOD(findcardStr)(/*[in]*/short hdev,/*[in]*/short mode,/*[out,retval]*/BSTR* strcard);
	STDMETHOD(mifareproCommandlink)(/*[in]*/short icdev,/*[in]*/BSTR sdata,/*[out,retval]*/BSTR* rdata);
	STDMETHOD(mifareproReset)(/*[in]*/short hdev,/*[out,retval]*/BSTR* resul);
    // 加入这2个方法 //2010.11.5
    //STDMETHOD(GetInterfaceSafetyOptions)(REFIID riid,DWORD *pdwSupportedOptions,DWORD *pdwEnabledOptions);
    //STDMETHOD(SetInterfaceSafetyOptions)(REFIID riid,DWORD dwOptionSetMask,DWORD dwEnabledOptions);

	STDMETHOD(findcardHex)(/*[in]*/short hdev,/*[in]*/short mode,/*[out,retval]*/BSTR* strcard);
	STDMETHOD(directWrite)(/*[in]*/short hdev,/*[in]*/short blk,/*[in]*/BSTR wtdata,/*[out,retval]*/short *resul);
	STDMETHOD(directRead)(/*[in]*/short hdev,/*[in]*/short blk,/*[out,retval]*/BSTR *blkdata);
	STDMETHOD(reset)(/*[in]*/short icdev,/*[in]*/short Msec,/*[out,retval]*/short *resul);
	STDMETHOD(fcpuCommandlink)(/*[in]*/short icdev,/*[in]*/short slen,/*[in]*/BSTR sdata,/*[in]*/short tt,/*[in]*/short FG,/*[out,retval]*/BSTR * rdata);
	STDMETHOD(fcpureset)(/*[in]*/short icdev,/*[out]*/short *rlen,/*[out,retval]*/BSTR* rbuf);
	STDMETHOD(halt)(/*[in]*/short hdev, /*[out,retval]*/short *resul);
	STDMETHOD(changkey)(/*[in]*/short hdev,/*[in]*/ short secNr,/*[in]*/ BSTR keya,/*[in]*/ BSTR ctrlword,/*[in]*/short bk,/*[in]*/ BSTR keyb,/*[out,retval]*/ short *resul );
	STDMETHOD(transfer)(/*[in]*/short hdev,/*[in]*/short blk,/*[out,retval]*/short *resul);
	STDMETHOD(decrement)(/*[in]*/short hdev,/*[in]*/ short blk,/*[in]*/ long value,/*[out,retval]*/ short *resul);
	STDMETHOD(increment)(/*[in]*/short hdev,/*[in]*/ short blk, /*[in]*/long value,/*[out,retval]*/short *resul);
	STDMETHOD(initialval)(/*[in]*/short hdev, /*[in]*/short blk, /*[in]*/long value, /*[out,retval]*/short *resul);
	STDMETHOD(readval)(/*[in]*/short hdev,/*[in]*/ short blk, /*[out,retval]*/long *value);
	STDMETHOD(write)(/*[in]*/short hdev,/*[in]*/short blk,/*[in]*/BSTR wtdata,/*[out,retval]*/short *resul);
	STDMETHOD(read)(/*[in]*/short hdev,/*[in]*/short blk,/*[out,retval]*/BSTR *blkdata);
	STDMETHOD(hexToUnchar)(/*[in]*/unsigned char *hex,/*[in]*/short chlen,/*[out,retval]*/unsigned char *a);
	STDMETHOD(loadkey)(/*[in]*/short hdev,/*[in]*/short mode,/*[in]*/ short sNr,/*[in]*/BSTR  key,/*[out,retval]*/short *resul);
	STDMETHOD(authentication)(/*[in]*/ short hdev,/*[in]*/short mode,/*[in]*/short snr,/*[out,retval]*/short *resul);
	STDMETHOD(findcard)(/*[in]*/int hdev,/*[in]*/short mode,/*[out,retval]*/long *ncard);
	STDMETHOD(uncharTounHex)(/*[in]*/unsigned char *a,/*[in]*/short hexlen,/*[out,retval]*/unsigned char *hex);
	STDMETHOD(hexTochar)(/*[in]*/BSTR hexstr,/*[in]*/short chlen,/*[out,retval]*/BSTR *charstr);
	STDMETHOD(select)(/*[in]*/short icdev,/*[in]*/long _Snr,/*[out,retval]*/short *resul);
	STDMETHOD(charToHex)(/*[in]*/BSTR charstr,/*[in]*/short hexlen,/*[out,retval]*/BSTR *hexstr);
	STDMETHOD(anticoll)(/*[in]*/short icdev,/*[in]*/short mode,/*[out,retval]*/long *ncard);
	STDMETHOD(beep)(/*[in]*/short icdev,/*[in]*/short isec,/*[out,retval]*/short *resul);
	STDMETHOD(request)(/*[in]*/short hdev,/*[in]*/short mode,/*[out,retval]*/short *resul);
	STDMETHOD(exit)(/*[in]*/short icdev,/*[out,retval]*/short *resul);

	STDMETHOD(initialcom)(/*[in]*/ int port,/*[in]*/long band,/*[out,retval]*/int *hdev);
	STDMETHOD(testfun)(LONG para1);

};

#endif //__UMFATL_H_
