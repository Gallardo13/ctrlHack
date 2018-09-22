export type YmapsMarker = {
  marker: ymaps.Placemark,
  data: any,
  id: string
}

export type YmapsMarkerInput = {
  coordinates: number[],
  data: any,
  id: string
}
