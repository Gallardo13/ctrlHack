export type YmapsMarker = {
  marker: ymaps.Placemark,
  data: any,
  id: string
}

export type YmapsMarkerInput = {
  coordinates: number[],
  data: YmapsMarkerData,
  id: string
}

export type YmapsMarkerData = {
  ContractNumber?: string,
  Address?: string,
  TempAddress?: string,
  ObjectType?: string,
  TempObjectType?: string,
  WorkType?: string,
  StartDate?: string | Date,
  FinishDate?: string | Date,
  CustomerName?: string,
  CustomerPhone?: string,
  ContractorName?: string,
  ContractorPhone?: string,
  Url?: string
}
